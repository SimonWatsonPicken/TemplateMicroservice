using FluentValidation;
using TemplateMicroservice.Api.Application.Commands;

namespace TemplateMicroservice.Api.Application.Validators
{
    public class SampleCommandValidator : AbstractValidator<SampleCommand>
    {
        public SampleCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0).WithMessage("The id must be greater than zero.");
            RuleFor(command => command.Name).NotEmpty().WithMessage("The name must not be empty.");
        }
    }
}