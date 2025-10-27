using JasperFx.Core;
using Marten;
using Wolverine;
using Wolverine.Attributes;

namespace AppWithMiddleware;

public static class DebitAccountHandler
{
    #region sample_DebitAccountHandler_that_uses_IMessageContext

    [Transactional]
    public static async Task Handle(
        DebitAccount command,
        Account account,
        IDocumentSession session,
        IMessageContext messaging)
    {
        account.Balance -= command.Amount;

        // This just marks the account as changed, but
        // doesn't actually commit changes to the database
        // yet. That actually matters as I hopefully explain
        session.Store(account);

        // Conditionally trigger other, cascading messages
        if (account.Balance > 0 && account.Balance < account.MinimumThreshold)
        {
            await messaging.SendAsync(new LowBalanceDetected(account.Id));
        }
        else if (account.Balance < 0)
        {
            await messaging.SendAsync(new AccountOverdrawn(account.Id), new DeliveryOptions{DeliverWithin = 1.Hours()});

            // Give the customer 10 days to deal with the overdrawn account
            await messaging.ScheduleAsync(new EnforceAccountOverdrawnDeadline(account.Id), 10.Days());
        }

        // "messaging" is a Wolverine IMessageContext or IMessageBus service
        // Do the deliver within rule on individual messages
        await messaging.SendAsync(new AccountUpdated(account.Id, account.Balance),
            new DeliveryOptions { DeliverWithin = 5.Seconds() });
    }

    #endregion
}