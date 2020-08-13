using System;
using System.Threading.Tasks;
using TemplateMicroservice.Api.Application.Commands;
using TemplateMicroservice.Api.Application.Handlers;

namespace TemplateMicroservice.Tests.TestDoubles.Stubs
{
    public class SampleCommandHandlerStub : ICommandHandler<SampleCommand>
    {
        private readonly CommandHandlerBehaviour _behaviour;

        public SampleCommandHandlerStub(CommandHandlerBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        public async Task<bool> Handle(SampleCommand command)
        {
            if (_behaviour == CommandHandlerBehaviour.ThrowsException)
            {
                throw new Exception("Test exception.");
            }

            return await Task.FromResult(true);
        }
    }
}