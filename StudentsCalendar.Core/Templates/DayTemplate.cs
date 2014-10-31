using System;
using System.Collections.Generic;

namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Szablon dzienny.
	/// </summary>
	public sealed class DayTemplate
	{
		private DayOfWeek _DayOfWeek;

		/// <summary>
		/// Pobiera dzień tygodnia, który dany szablon opisuje.
		/// </summary>
		public DayOfWeek DayOfWeek
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

		public DayTemplate(DayOfWeek dayOfWeek)
		{
			this._DayOfWeek = dayOfWeek;
		}
	}
}
