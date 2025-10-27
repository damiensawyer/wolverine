namespace AppWithMiddleware;

public record LowBalanceDetected(Guid AccountId) : IAccountCommand;