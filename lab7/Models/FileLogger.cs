using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DB_course.Models
{
    public class FileLogger : ILogger, IDisposable
    {
        string filePath;
        static object _lock = new object();
        string category;
        public FileLogger(string path, string category)
        {
            filePath = path;
            this.category = category;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose() { }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
          
                File.AppendAllText(filePath, logLevel + "{ "+category +" }"+"  " + formatter(state, exception) + Environment.NewLine);
            }
        }

    }
    public class FileLoggerProvider : ILoggerProvider
    {
        string path;
        public FileLoggerProvider(string path)
        {
            this.path = path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path, categoryName);
        }

        public void Dispose() { }
    }
    public static class FileLoggerExtensions
    {
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filePath)
        {
            builder.AddProvider(new FileLoggerProvider(filePath));
            return builder;
        }
        public static void LogError(this ILogger logger, string? message, params object?[] args)
        {
            logger.Log(LogLevel.Error, message, args);
        }
        public static void LogInformation(this ILogger logger, string? message, params object?[] args)
        {
            logger.Log(LogLevel.Information, message, args);
        }
        public static void LogWarning(this ILogger logger, string? message, params object?[] args)
        {
            logger.Log(LogLevel.Warning, message, args);
        }
        public static void LogDebug(this ILogger logger, string? message, params object?[] args)
        {
            logger.Log(LogLevel.Debug, message, args);
        }
    }

}
