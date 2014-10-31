using System.Collections.Generic;
using NodaTime;
using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Szablon dzienny.
	/// </summary>
	public sealed class DayTemplate
	{
		private readonly IsoDayOfWeek _DayOfWeek;

		/// <summary>
		/// Pobiera dzień tygodnia, który dany szablon opisuje.
		/// </summary>
		public IsoDayOfWeek DayOfWeek
		{
			get { return this._DayOfWeek; }
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
		/// Lista modyfikatorów przypisanych do dnia.
		/// </summary>
		public IList<IDayModifier> Modifiers { get; set; }

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
