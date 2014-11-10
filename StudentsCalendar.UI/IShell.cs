namespace StudentsCalendar.UI
{
	/// <summary>
	/// Główny obiekt aplikacji - obsługuje nawigację w ramach aplikacji.
	/// </summary>
	public interface IShell
	{
		/// <summary>
		/// Wyświetla nowy ekran ekran główny.
		/// </summary>
		/// <remarks>
		/// Jeśli <typeparamref name="TViewModel"/> implementuje interfejs <see cref="IHaveContext{TData}"/>,
		/// obiekt wywołujący tą metodę jest odpowiedzialny za wywołanie <see cref="IHaveContext{TData}.UpdateContext"/>.
		/// </remarks>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns>Utworzony ViewModel.</returns>
		TViewModel NavigateTo<TViewModel>()
			where TViewModel : IMainScreen;

		/// <summary>
		/// Wyświetla "wyskakujące okienko".
		/// </summary>
		/// <remarks>
		/// Metoda ta może zarówno podmieniać ekran(Windows Phone) jak i wyświetlać
		/// ekran, przykrywający główny ekran aplikacji.
		/// 
		/// Jeśli <typeparamref name="TViewModel"/> implementuje interfejs <see cref="IHaveContext{TData}"/>,
		/// obiekt wywołujący tą metodę jest odpowiedzialny za wywołanie <see cref="IHaveContext{TData}.UpdateContext"/>.
		/// </remarks>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns>Utworzony ViewModel.</returns>
		TViewModel Show<TViewModel>()
			where TViewModel : IPopupScreen;
	}
}
