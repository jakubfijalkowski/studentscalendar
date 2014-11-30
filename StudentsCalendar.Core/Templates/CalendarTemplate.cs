using System.Collections.Generic;
using NodaTime;
using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Szablon kalendarza.
	/// </summary>
	public sealed class CalendarTemplate
	{
		private readonly string _Id;

		/// <summary>
		/// Pobiera wewnętrzny identyfikator kalendarza.
		/// </summary>
		public string Id
		{
			get { return this._Id; }
		}

		/// <summary>
		/// Pobiera lub zmienia nazwę szablonu.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Pobiera lub zmienia bazowy szablon tygodniowy.
		/// </summary>
		public WeekTemplate WeekTemplate { get; set; }

		/// <summary>
		/// Pobiera lub zmienia początkową datę aktywności kalendarza.
		/// </summary>
		public LocalDate StartDate { get; set; }

		/// <summary>
		/// Pobiera lub zmienia końcową datę aktywności kalendarza.
		/// </summary>
		public LocalDate EndDate { get; set; }

		/// <summary>
		/// Lista modyfikatorów przypisana do całego kalendarza.
		/// </summary>
		public IList<ICalendarModifier> Modifiers { get; set; }

		public CalendarTemplate(string id)
		{
			this._Id = id;
		}
	}
}
