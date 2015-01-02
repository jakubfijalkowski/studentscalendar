namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// "Marker interface" dla generatorów - istnieje tylko w celu uproszczenia dokumentacji.
	/// </summary>
	/// <remarks>
	/// Generator ma za zadanie:
	///   1. Stworzyć obiekt pośredni ze wskazanego(np. <see cref="ClassesTemplate"/> -> <see cref="IntermediateClasses"/>),
	///      który będzie reprezentował obiekt o wskazanej dacie(nie dotyczy <see cref="CalendarTempalte"/>).
	///   2. Wygenerować obiekty-dzieci(np. zajęcia dla szablonu dnia).
	///   3. Zaaplikować aktywne modyfikatory.
	/// Generator ma dostęp do pełnego potoku generowania, którym zarządza <see cref="IGenerationEngine"/>.
	/// </remarks>
	public interface IGenerator
	{ }
}
