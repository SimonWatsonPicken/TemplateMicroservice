using TemplateMicroservice.Api.Application.Commands;

namespace TemplateMicroservice.Tests.ObjectMothers
{
    internal class SampleCommandMother
    {
        public static SampleCommand GetValidCommand()
        {
            return new SampleCommand
            {
                Id = 1,
                Name = "Feed"
            };
        }
    }
}