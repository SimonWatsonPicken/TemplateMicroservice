using System;
using Microsoft.Extensions.Logging;

namespace TemplateMicroservice.Tests.TestDoubles.Spies
{
    public class LoggerSpy<T> : ILogger<T>
    {
        public bool LogWasCalled { get; set; }

        public string Message { get; set; }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            LogWasCalled = true;
            Message = state.ToString();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}