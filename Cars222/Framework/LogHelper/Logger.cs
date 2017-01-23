using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;

namespace Framework.LogHelper
{
    public class Logger
    {
        public static ILog logger;
        public static ConsoleAppender consoleAppender;
        public static FileAppender fileAppender;
        public static string layout = "%date{ABSOLUTE} [%level] - [%class] \t\t [%method] \t\t %message%newline";

        public static string Layout
        {
            set { layout = value; }
        }

        private static PatternLayout GetPatternLayout()
        {
            layout.PadLeft(10);
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = layout
            };
            patternLayout.ActivateOptions();
            return patternLayout;
        }

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All
            };

            consoleAppender.ActivateOptions();

            return consoleAppender;
        }

        public static FileAppender GetFileAppender()
        {
            fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = false,
                File = "FileLogger.log"
            };

            fileAppender.ActivateOptions();

            return fileAppender;
        }

        public static ILog GetLogger(Type type)
        {
            if (consoleAppender == null)
                consoleAppender = GetConsoleAppender();

            if (fileAppender == null)
                fileAppender = GetFileAppender();

            if (logger != null)
                return logger;

            BasicConfigurator.Configure(consoleAppender, fileAppender);
            logger = LogManager.GetLogger(type);

            return logger;
        }
    }
}
