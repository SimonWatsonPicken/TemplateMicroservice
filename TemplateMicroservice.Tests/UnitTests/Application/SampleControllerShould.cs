using Microsoft.AspNetCore.Mvc;
using TemplateMicroservice.Api.Application.Commands;
using TemplateMicroservice.Api.Controllers;
using TemplateMicroservice.Tests.TestDoubles.Spies;
using TemplateMicroservice.Tests.TestDoubles.Stubs;
using Xunit;

namespace TemplateMicroservice.Tests.UnitTests.Application
{
   public class SampleControllerShould
    {
        private readonly LoggerSpy<SampleController> _logger;

        public SampleControllerShould()
        {
            _logger = new LoggerSpy<SampleController>();
        }

        [Fact]
        public void ReturnBadRequestIfSendEmailCommandNotHandled()
        {
            // Arrange.
            var sampleCommandHandler = new SampleCommandHandlerStub(CommandHandlerBehaviour.ThrowsException);
            var controller = new SampleController(sampleCommandHandler, _logger);

            // Act.
            var result = controller.PostDoSomething(new SampleCommand()).Result;

            // Assert.
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void ReturnOkIfSendEmailCommandIsHandled()
        {
            // Arrange.
            var sampleCommandHandler = new SampleCommandHandlerStub(CommandHandlerBehaviour.Default);
            var controller = new SampleController(sampleCommandHandler, _logger);

            // Act.
            var result = controller.PostDoSomething(new SampleCommand()).Result;

            // Assert.
            Assert.IsType<OkObjectResult>(result);
        }
    }
}