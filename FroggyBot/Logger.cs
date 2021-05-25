using System;

namespace FroggyBot {
    public enum LogLevel {
        Trace = 0,
        Debug = 1,
        Info = 2,
        Warning = 3,
        Error = 4
    }

    public static class Logger {
        private static LogLevel _minLevel;
        private static readonly object _lock = new object();

        public static void Trace(string message) => Log(LogLevel.Trace, message);
        public static void Debug(string message) => Log(LogLevel.Debug, message);
        public static void Info(string message) => Log(LogLevel.Info, message);
        public static void Warning(string message) => Log(LogLevel.Warning, message);
        public static void Error(string message) => Log(LogLevel.Error, message);

        public static void Initialize(LogLevel minLevel) {
            _minLevel = minLevel;
        }

        private static void Log(LogLevel level, string message) {
            if (level < _minLevel)
                return;

            lock (_lock) {
                Console.ForegroundColor = GetColor(level);
                Console.Write($"[{level}] ");
                Console.ResetColor();
                Console.Write(message);
                Console.WriteLine("🐸");
            }
        }

        private static ConsoleColor GetColor(LogLevel level) {
            switch (level) {
                case LogLevel.Trace:
                return ConsoleColor.Magenta;
                case LogLevel.Debug:
                return ConsoleColor.Cyan;
                case LogLevel.Info:
                return ConsoleColor.Green;
                case LogLevel.Warning:
                return ConsoleColor.DarkYellow;
                case LogLevel.Error:
                return ConsoleColor.Red;
                default:
                return ConsoleColor.White;
            }
        }
    }
}
