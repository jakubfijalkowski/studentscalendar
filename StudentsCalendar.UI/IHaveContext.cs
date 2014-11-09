namespace StudentsCalendar.UI
{
	/// <summary>
	/// Określa view modele, które muszą być inicjalizowane dodatkowymi informacjami(np. obiektem do edycji).
	/// </summary>
	public interface IHaveContext<TData>
	{
		/// <summary>
		/// Zmienia kontekst obiektu.
		/// </summary>
		/// <param name="context"></param>
		void UpdateContext(TData context);
	}
}
