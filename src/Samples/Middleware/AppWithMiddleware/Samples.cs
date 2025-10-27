using Marten;

namespace AppWithMiddleware;

public static class Samples
{
    #region sample_common_scenario

    public static async Task Handle(DebitAccount command, IDocumentSession session, ILogger logger)
    {
        // Try to find a matching account for the incoming command
        var account = await session.LoadAsync<Account>(command.AccountId);
        if (account == null)
        {
            logger.LogInformation("Referenced account {AccountId} does not exist", command.AccountId);
            return;
        }

        // do the real processing
    }

    #endregion
}