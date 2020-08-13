using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemplateMicroservice.Api.Application.Commands;
using TemplateMicroservice.Api.Application.Handlers;

namespace TemplateMicroservice.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ICommandHandler<SampleCommand> _sampleCommandHandler;
        private readonly ILogger<SampleController> _logger;

        public SampleController(ICommandHandler<SampleCommand> sampleCommandHandler, ILogger<SampleController> logger)
        {
            _sampleCommandHandler = sampleCommandHandler;
            _logger = logger;
        }

        [HttpPost("DoSomething")]
        public async Task<ActionResult> PostDoSomething(SampleCommand command)
        {
            try
            {
                var result = await _sampleCommandHandler.Handle(command);

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                return BadRequest();
            }
        }
    }
}