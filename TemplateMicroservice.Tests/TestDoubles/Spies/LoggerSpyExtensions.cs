using System;
using Microsoft.Extensions.Logging;
// ReSharper disable UnusedMember.Global

namespace TemplateMicroservice.Tests.TestDoubles.Spies
{
    public static class LoggerSpyExtensions
    {
        public static void LogError<T>(this LoggerSpy<T> logger, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Error, exception, message, args);
        }

        public static void Log<T>(this LoggerSpy<T> logger, LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            logger.Log(logLevel, 0, exception, message, args);
        }

        public static void Log<T>(this LoggerSpy<T> logger, LogLevel logLevel, EventId eventId, Exception exception, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(logLevel, eventId, message, exception, null);
        }
    }
}