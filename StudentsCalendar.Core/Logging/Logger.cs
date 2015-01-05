using System;

namespace StudentsCalendar.Core.Logging
{
	public class Logger
		: ILogger
	{
		private readonly LoggerConfiguration Config;

		public void Debug(string format, params object[] objs)
		{
			this.Log(LogLevel.Debug, null, format, objs);
		}

		public void Info(string format, params object[] objs)
		{
			this.Log(LogLevel.Info, null, format, objs);
		}

		public void Warn(string format, params object[] objs)
		{
			this.Log(LogLevel.Warn, null, format, objs);
		}

		public void Warn(Exception ex, string format, params object[] objs)
		{
			this.Log(LogLevel.Warn, ex, format, objs);
		}

		public void Error(string format, params object[] objs)
		{
			this.Log(LogLevel.Error, null, format, objs);
		}

		public void Error(Exception ex, string format, params object[] objs)
		{
			this.Log(LogLevel.Error, ex, format, objs);
		}

		public void Fatal(string format, params object[] objs)
		{
			this.Log(LogLevel.Fatal, null, format, objs);
		}

		public void Fatal(Exception ex, string format, params object[] objs)
		{
			this.Log(LogLevel.Fatal, ex, format, objs);
		}

		public Logger(LoggerConfiguration config)
		{
			this.Config = config;
		}

		private void Log(LogLevel level, Exception ex, string format, object[] objs)
		{
			if (level >= this.Config.MinLevel && level <= this.Config.MaxLevel)
			{
				var entry = new LogEntry
				{
					Level = level,
					Date = DateTime.UtcNow,
					Exception = ex,
					Message = string.Format(format, objs)
				};
				foreach (var target in this.Config.Targets)
				{
					target.Write(entry);
				}
			}
		}
	}
}
