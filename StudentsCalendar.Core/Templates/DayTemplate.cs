using System.Collections.Generic;
using NodaTime;

namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Szablon dzienny.
	/// </summary>
	public sealed class DayTemplate
	{
		private IsoDayOfWeek _DayOfWeek;

		/// <summary>
		/// Pobiera dzień tygodnia, który dany szablon opisuje.
		/// </summary>
		public IsoDayOfWeek DayOfWeek
		{
			get { return this._DayOfWeek; }
			set { this._DayOfWeek = value; }
		}


		/// <summary>
		/// Pobiera lub zmienia listę zajęć danego dnia.
		/// </summary>
		public IList<ClassesTemplate> Classes { get; set; }

		/// <summary>
		/// Pobiera lub zmienia notatki.
		/// </summary>
		public string Notes { get; set; }

		/// <summary>
		/// Inicjalizuje szablon dzienny na konkretny dzień tygodnia.
		/// </summary>
		/// <param name="dayOfWeek"></param>
		public DayTemplate(IsoDayOfWeek dayOfWeek)
		{
			this._DayOfWeek = dayOfWeek;
		}
	}
}
