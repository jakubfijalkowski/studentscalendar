namespace StudentsCalendar.UI.Logging
{
	/// <summary>
	/// Cel loggera - miejsce, gdzie logi będą zapisywane.
	/// </summary>
	public interface ITarget
	{
		/// <summary>
		/// Zapisuje pojedynczy wpis.
		/// </summary>
		/// <param name="entry"></param>
		void Write(LogEntry entry);
	}
}
