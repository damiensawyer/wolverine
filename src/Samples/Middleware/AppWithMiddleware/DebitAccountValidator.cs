using FluentValidation;

namespace AppWithMiddleware;

public class DebitAccountValidator : AbstractValidator<DebitAccount>
{
    public DebitAccountValidator()
    {
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}