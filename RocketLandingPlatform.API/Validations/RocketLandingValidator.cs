using FluentValidation;
using RocketLandingPlatform.API.DTO;

namespace RocketLandingPlatform.API.Validations
{
    public class RocketLandingValidator : AbstractValidator<RocketLandingDTO>
    {
        public RocketLandingValidator()
        {
            RuleFor(r => r.X)
                .NotEmpty()
                .WithMessage("X coordinates is required!")
                .GreaterThan(-1)
                .WithMessage("X must be positive number");
            RuleFor(r => r.Y)
                .NotEmpty()
                .WithMessage("Y coordinates is required!")
                .GreaterThan(-1)
                .WithMessage("Y must be positive number");
        }
    }
}
