using TemplateMicroservice.Api.Application.Commands;
using TemplateMicroservice.Api.Application.Handlers;
using TemplateMicroservice.Infrastructure.Providers.SampleProvider;
using TemplateMicroservice.Tests.ObjectMothers;
using TemplateMicroservice.Tests.TestDoubles.Spies;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Application
{
   public class SampleCommandHandlerShould
    {
        private readonly LoggerSpy<SampleCommandHandler> _logger = new LoggerSpy<SampleCommandHandler>();

        [Fact]
        public void ThrowValidationExceptionIfCommandIsInvalid()
        {
            // Arrange.
            var handler = new SampleCommandHandler(new SampleProvider(), _logger);

            // Act.
            var result = handler.Handle(new SampleCommand()).Result;

            // Assert.
            Assert.False(result);
            Assert.True(_logger.LogWasCalled);
            Assert.Equal("An invalid command was passed to the sample handler.", _logger.Message);
        }

        [Fact]
        public void SucceedIfCommandIsValid()
        {
            // Arrange.
            var handler = new SampleCommandHandler(new SampleProvider(), _logger);
            var command = SampleCommandMother.GetValidCommand();

            // Act.
            var result = handler.Handle(command).Result;

            // Assert.
            Assert.True(result);
            Assert.False(_logger.LogWasCalled);
        }
    }
}