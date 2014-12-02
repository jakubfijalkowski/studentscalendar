using System;
using StudentsCalendar.Core.ActivitySpans;

namespace StudentsCalendar.UI
{
	/// <summary>
	/// Platform-specific lokator dla widoków edycji przedziałów aktywności.
	/// </summary>
	public interface IActivitySpanViewLocator
	{
		/// <summary>
		/// Wskazuje typ, który powinien być wyświetlony wzamian wskazanego przedziału.
		/// </summary>
		/// <param name="span"></param>
		/// <returns></returns>
		Type LocateView(IActivitySpan span);
	}
}
