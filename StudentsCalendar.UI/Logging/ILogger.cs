using System;

namespace StudentsCalendar.UI.Logging
{
	/// <summary>
	/// Logger
	/// </summary>
	public interface ILogger
	{
		void Debug(string format, params object[] objs);
		void Error(Exception ex, string format, params object[] objs);
		void Error(string format, params object[] objs);
		void Fatal(Exception ex, string format, params object[] objs);
		void Fatal(string format, params object[] objs);
		void Info(string format, params object[] objs);
		void Warn(Exception ex, string format, params object[] objs);
		void Warn(string format, params object[] objs);
	}
}
