using System;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Logging;

namespace DotNet.Tools.Docker
{
    public class CommandOutputProvider : ILoggerProvider
    {
        private readonly bool _isWindows;

        public CommandOutputProvider(IRuntimeEnvironment runtimeEnv)
        {
            _isWindows = runtimeEnv.OperatingSystem == "Windows";
        }

        public ILogger CreateLogger(string name)
        {
            return new CommandOutputLogger(this, name, useConsoleColor: _isWindows);
        }

        public void Dispose()
        {
        }

        public LogLevel LogLevel { get; set; } = LogLevel.Information;
    }
}