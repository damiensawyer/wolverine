namespace AppWithMiddleware;

public record AccountOverdrawn(Guid AccountId) : IAccountCommand;