using System;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// Dane zdarzenia dodania nowych zajęć.
	/// </summary>
	public sealed class AddClassesEventArgs
		: EventArgs
	{
		private readonly CalendarEditSlot _EditSlot;

		/// <summary>
		/// Pobiera slot, który został użyty.
		/// </summary>
		public CalendarEditSlot EditSlot
		{
			get { return this._EditSlot; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		/// <param name="slot"></param>
		public AddClassesEventArgs(CalendarEditSlot slot)
		{
			this._EditSlot = slot;
		}
	}
}
