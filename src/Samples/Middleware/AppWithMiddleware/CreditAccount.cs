namespace AppWithMiddleware;

public record CreditAccount(Guid AccountId, decimal Amount) : IAccountCommand;