using StudentsCalendar.Core.ActivitySpans;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	/// <summary>
	/// ViewModel opisujący <see cref="IActivitySpan"/>. Pozwala na edycję przedziałów.
	/// Nie powinien być implementowany ręcznie - używany tylko do uproszczenia kodu.
	/// </summary>
	public interface IActivitySpanViewModel
	{
		/// <summary>
		/// Pobiera lub zmienia nazwę przedziału aktywności, który dany ViewModel opisuje.
		/// </summary>
		IActivitySpan Span { get; set; }

		/// <summary>
		/// Pobiera ogólną nazwę dla przedziału aktywności.
		/// </summary>
		string Name { get; }
	}
}
