using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using FluentAssertions;
using Xunit;

namespace Chapter07
{
    /*
        Functions everywhere. You may still have a feeling that objects are ultimately more powerful than functions. Surely a logger object should expose methods for related operations such as Debug, Info, and Error? To see that this is not necessarily so, challenge yourself to write a very simple logging mechanism (logging to the console is fine) that doesn’t require any classes or structs. You should still be able to inject a Log value into a consumer class or function, exposing the operations Debug, Info, and Error, like so:

            void ConsumeLog(Log log)
                => log.Info("look! no classes!");
     */
    public class Exercise3
    {
        // TODO: Revisit this later
    }

    public static class LogExtensions
    {
        public enum Level { Debug, Info, Error }

        public delegate void Log(Level level, string message);

        public static Log consoleLogger = (Level level, string message) => Console.WriteLine($"[{level}]: {message}");

        public static void Debug(this Log log, string message) => log(Level.Debug, message);
        public static void Info(this Log log, string message) => log(Level.Info, message);
        public static void Error(this Log log, string message) => log(Level.Error, message);

        public static void _main() => ConsumeLog(consoleLogger);
        public static void ConsumeLog(Log log) => log.Info("look! no classes!");
    }
}
