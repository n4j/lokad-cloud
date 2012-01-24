using System;
using System.Globalization;
using System.Xml.Linq;

namespace Lokad.Cloud.Diagnostics
{
    /// <summary>
    /// Helper extensions for any class that implements <see cref="ILog"/>
    /// </summary>
    public static class LogExtensions
    {
        static readonly CultureInfo Culture = CultureInfo.InvariantCulture;

        /// <summary>
        /// Tries to write a log entry.
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="level">The importance level</param>
        /// <param name="message">The actual message</param>
        /// <param name="exception">The actual exception</param>
        /// <param name="meta">Optional semantic meta data</param>
        public static bool TryLog(this ILog log, LogLevel level, string message, Exception exception = null, XElement meta = null)
        {
            try
            {
                log.Log(level, message, exception, meta);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Build a log entry incrementally with a builder
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        public static LogEntryBuilder Debug(this ILog log)
        {
            return new LogEntryBuilder(log, LogLevel.Debug);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Debug"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="meta">Optional semantic meta data</param>
        public static bool TryDebug(this ILog log, string message, Exception exception = null, XElement meta = null)
        {
            return log.TryLog(LogLevel.Debug, message, exception, meta);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Debug"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryDebugFormat(this ILog log, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Debug, string.Format(Culture, format, args));
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Debug"/> level and
        /// appends the specified <see cref="Exception"/>
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryDebugFormat(this ILog log, Exception exception, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Debug, string.Format(Culture, format, args), exception);
        }

        /// <summary>
        /// Build a log entry incrementally with a builder
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        public static LogEntryBuilder Info(this ILog log)
        {
            return new LogEntryBuilder(log, LogLevel.Info);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Info"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="meta">Optional semantic meta data</param>
        public static bool TryInfo(this ILog log, string message, Exception exception = null, XElement meta = null)
        {
            return log.TryLog(LogLevel.Info, message, exception, meta);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Info"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryInfoFormat(this ILog log, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Info, string.Format(Culture, format, args));
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Info"/> level and
        /// appends the specified <see cref="Exception"/>
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryInfoFormat(this ILog log, Exception exception, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Info, string.Format(Culture, format, args), exception);
        }

        /// <summary>
        /// Build a log entry incrementally with a builder
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        public static LogEntryBuilder Warn(this ILog log)
        {
            return new LogEntryBuilder(log, LogLevel.Warn);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Warn"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="meta">Optional semantic meta data</param>
        public static bool TryWarn(this ILog log, string message, Exception exception = null, XElement meta = null)
        {
            return log.TryLog(LogLevel.Warn, message, exception, meta);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Warn"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryWarnFormat(this ILog log, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Warn, string.Format(Culture, format, args));
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Warn"/> level and
        /// appends the specified <see cref="Exception"/>
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryWarnFormat(this ILog log, Exception exception, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Warn, string.Format(Culture, format, args), exception);
        }

        /// <summary>
        /// Build a log entry incrementally with a builder
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        public static LogEntryBuilder Error(this ILog log)
        {
            return new LogEntryBuilder(log, LogLevel.Error);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Error"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="meta">Optional semantic meta data</param>
        public static bool TryError(this ILog log, string message, Exception exception = null, XElement meta = null)
        {
            return log.TryLog(LogLevel.Error, message, exception, meta);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Error"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryErrorFormat(this ILog log, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Error, string.Format(Culture, format, args));
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Error"/> level and
        /// appends the specified <see cref="Exception"/>
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryErrorFormat(this ILog log, Exception exception, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Error, string.Format(Culture, format, args), exception);
        }

        /// <summary>
        /// Build a log entry incrementally with a builder
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        public static LogEntryBuilder Fatal(this ILog log)
        {
            return new LogEntryBuilder(log, LogLevel.Fatal);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Fatal"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="meta">Optional semantic meta data</param>
        public static bool TryFatal(this ILog log, string message, Exception exception = null, XElement meta = null)
        {
            return log.TryLog(LogLevel.Fatal, message, exception, meta);
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Fatal"/> level
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryFatalFormat(this ILog log, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Fatal, string.Format(Culture, format, args));
        }

        /// <summary>
        /// Writes message with <see cref="LogLevel.Fatal"/> level and
        /// appends the specified <see cref="Exception"/>
        /// </summary>
        /// <param name="log">Log instance being extended</param>
        /// <param name="exception">Exception to add to the message</param>
        /// <param name="format">Format string as in 
        /// <see cref="string.Format(string,object[])"/></param>
        /// <param name="args">Arguments</param>
        public static bool TryFatalFormat(this ILog log, Exception exception, string format, params object[] args)
        {
            return log.TryLog(LogLevel.Fatal, string.Format(Culture, format, args), exception);
        }
    }
}