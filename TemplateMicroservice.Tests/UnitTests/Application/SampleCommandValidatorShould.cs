using FluentValidation.TestHelper;
using TemplateMicroservice.Api.Application.Validators;
using TemplateMicroservice.Tests.ObjectMothers;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Application
{
    public class SampleCommandValidatorShould
    {
        private readonly SampleCommandValidator _validator;

        public SampleCommandValidatorShould()
        {
            _validator = new SampleCommandValidator();
        }
        
        [Fact]
        public void FailWhenIdIsZero()
        {
            // Arrange.
            var command = SampleCommandMother.GetValidCommand();
            command.Id = 0;

            // Act.
            // Assert.
            _validator.ShouldHaveValidationErrorFor(x => x.Id, command).WithErrorMessage("The id must be greater than zero.");
        }
        
        [Fact]
        public void FailWhenIdIsLessThanZero()
        {
            // Arrange.
            var command = SampleCommandMother.GetValidCommand();
            command.Id = -1;

            // Act.
            // Assert.
            _validator.ShouldHaveValidationErrorFor(x => x.Id, command).WithErrorMessage("The id must be greater than zero.");
        }
        
        [Fact]
        public void FailWhenIdNameIsEmpty()
        {
            // Arrange.
            var command = SampleCommandMother.GetValidCommand();
            command.Name = string.Empty;

            // Act.
            // Assert.
            _validator.ShouldHaveValidationErrorFor(x => x.Name, command).WithErrorMessage("The name must not be empty.");
        }

        [Fact]
        public void SucceedWhenCommandIsValid()
        {
            // Arrange.
            var command = SampleCommandMother.GetValidCommand();

            // Act.
            var result = _validator.Validate(command);

            // Assert.
            Assert.True(result.IsValid);
        }
    }
}