using Marten;

namespace AppWithMiddleware;

public static class CreditAccountHandler
{
    public static void Handle(
        CreditAccount command,

        // Wouldn't it be nice to just have Wolverine "push"
        // the right account into this method?
        Account account,

        // Using Marten for persistence here
        IDocumentSession session)
    {
        account.Balance += command.Amount;

        // Just mark this account as needing to be updated
        // in the database
        session.Store(account);
    }
}