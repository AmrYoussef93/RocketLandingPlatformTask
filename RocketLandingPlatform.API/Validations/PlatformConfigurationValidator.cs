using FluentValidation;
using RocketLandingPlatform.API.DTO;

namespace RocketLandingPlatform.API.Validations
{
    public class PlatformConfigurationValidator : AbstractValidator<PlatformConfigurationDTO>
    {
        public PlatformConfigurationValidator()
        {
            RuleFor(p => p.Size)
                .NotEmpty()
                .WithMessage("X coordinates is required!")
                .GreaterThan(0)
                .WithMessage("X must be greater than 0");

            RuleFor(p => p.StartingPosition.X)
                .NotEmpty()
                .WithMessage("X coordinates is required!")
                .GreaterThan(-1)
                .WithMessage("X must be positive number");
            RuleFor(p => p.StartingPosition.X)
                .NotEmpty()
                .WithMessage("Y coordinates is required!")
                .GreaterThan(-1)
                .WithMessage("Y must be positive number");
        }
    }
}
