using System;
using System.Threading.Tasks;
using TemplateMicroservice.Api.Application.Commands;
using TemplateMicroservice.Api.Application.Handlers;
using TemplateMicroservice.Api.Application.Model;

namespace TemplateMicroservice.Tests.TestDoubles.Stubs
{
    public class SampleCommandHandlerStub : ICommandHandler<SampleCommand>
    {
        private readonly CommandHandlerBehaviour _behaviour;

        public SampleCommandHandlerStub(CommandHandlerBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        public async Task<SampleUiEntity> Handle(SampleCommand command)
        {
            if (_behaviour == CommandHandlerBehaviour.ThrowsException)
            {
                throw new Exception("Test exception.");
            }

            return await Task.FromResult(new SampleUiEntity());
        }
    }
}