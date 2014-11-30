using System;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// Dane zdarzenia edycji/usunięcia zajęć.
	/// </summary>
	public sealed class ClassesEditEventArgs
		: EventArgs
	{
		private readonly CalendarEditSlot _EditSlot;
		private readonly ClassesTemplate _Template;

		/// <summary>
		/// Pobiera slot, który został użyty.
		/// </summary>
		public CalendarEditSlot EditSlot
		{
			get { return this._EditSlot; }
		}

		/// <summary>
		/// Pobiera kliknięty szablon.
		/// </summary>
		public ClassesTemplate Template
		{
			get { return this._Template; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		/// <param name="slot"></param>
		/// <param name="template"></param>
		public ClassesEditEventArgs(CalendarEditSlot slot, ClassesTemplate template)
		{
			this._EditSlot = slot;
			this._Template = template;
		}
	}
}
