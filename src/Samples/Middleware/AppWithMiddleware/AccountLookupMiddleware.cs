using Marten;
using Wolverine;

namespace AppWithMiddleware;

public static class AccountLookupMiddleware
{
    // The message *has* to be first in the parameter list
    // Before or BeforeAsync tells Wolverine this method should be called before the actual action
    public static async Task<(HandlerContinuation, Account?, OutgoingMessages)> LoadAsync(
        IAccountCommand command,
        ILogger logger,

        // This app is using Marten for persistence
        IDocumentSession session,

        CancellationToken cancellation)
    {
        var messages = new OutgoingMessages();
        var account = await session.LoadAsync<Account>(command.AccountId, cancellation);
        if (account == null)
        {
            logger.LogInformation("Unable to find an account for {AccountId}, aborting the requested operation", command.AccountId);

            messages.RespondToSender(new InvalidAccount(command.AccountId));
            return (HandlerContinuation.Stop, null, messages);
        }

        // messages would be empty here
        return (HandlerContinuation.Continue, account, messages);
    }
}