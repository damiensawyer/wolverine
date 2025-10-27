using Wolverine.Attributes;

namespace AppWithMiddleware;

[DeliverWithin(5)]
public record AccountUpdated(Guid AccountId, decimal Balance);