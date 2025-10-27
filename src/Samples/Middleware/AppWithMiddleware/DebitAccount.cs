namespace AppWithMiddleware;

public record DebitAccount(Guid AccountId, decimal Amount) : IAccountCommand;