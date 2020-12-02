using FluentValidation;
using TemplateMicroservice.Api.Application.Commands;

namespace TemplateMicroservice.Api.Application.Validators
{
    public class SampleCommandValidator : AbstractValidator<SampleCommand>
    {
        public SampleCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().WithMessage("The name must not be empty.");
        }
    }
}