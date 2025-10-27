using JasperFx.Core;
using Wolverine;

namespace AppWithMiddleware;

public record EnforceAccountOverdrawnDeadline(Guid AccountId) : TimeoutMessage(10.Days()), IAccountCommand;