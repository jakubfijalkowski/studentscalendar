namespace StudentsCalendar.UI.Dialogs
{
	/// <summary>
	/// Dialog błędu.
	/// </summary>
	public sealed class ErrorDialog
	{
		/// <summary>
		/// Pobiera lub zmienia tytuł wyświetlany na dialogu.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Pobiera lub zmienia treść wiadomości.
		/// </summary>
		public string Message { get; set; }
	}
}
