namespace StudentsCalendar.UI
{
	/// <summary>
	/// Określa view modele, które muszą być inicjalizowane dodatkowymi informacjami(np. obiektem do edycji).
	/// </summary>
	public interface IHaveContext<TData>
		: IViewModel
	{
		/// <summary>
		/// Pobiera lub zmienia kontekst ViewModelu.
		/// </summary>
		TData Context { get; set; }
	}
}
