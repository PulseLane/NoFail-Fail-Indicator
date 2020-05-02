using IPALogger = IPA.Logging.Logger;
using LogLevel = IPA.Logging.Logger.Level;

namespace NoFail_Fail_Indicator
{
    internal static class Logger
    {
        public static IPALogger log { get; set; }
        internal static void Log(string message, LogLevel severity = LogLevel.Info) => log.Log(severity, message);
    }
}
