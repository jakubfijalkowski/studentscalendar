using System;
using System.Threading.Tasks;

namespace StudentsCalendar.UI
{
	/// <summary>
	/// Główny obiekt aplikacji okienkowej - obsługuje nawigację w ramach aplikacji.
	/// </summary>
	public interface IShell
	{
		/// <summary>
		/// Wyświetla nowy ekran główny.
		/// </summary>
		/// <param name="viewModelType">Typ ViewModelu dla ekranu.</param>
		void ShowMainScreen(Type viewModelType);

		/// <summary>
		/// Wyświetla "wyskakujące okienko".
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns>Utworzony ViewModel.</returns>
		TViewModel ShowPopup<TViewModel>()
			where TViewModel : IViewModel;

		/// <summary>
		/// Wyświetla okno dialogowe o wskazanym typie modelu.
		/// </summary>
		/// <remarks>
		/// Model powinien zostać ustawiony jako kontekst(<c>DataContext</c>) kontrolki
		/// reprezentującej dialog.
		/// </remarks>
		/// <param name="model"></param>
		/// <returns><see cref="Task"/>, który pozwala poczekać na zamknięcie okna.</returns>
		Task ShowDialog(object model);

		/// <summary>
		/// Wyświetla ekran ładowania i wyłącza możliwość nawigacji z wewnątrz
		/// shella.
		/// </summary>
		/// <returns>
		/// Obiekt <see cref="IDisposable"/>, który przy wywołaniu <see cref="IDisposable.Dispose"/>
		/// ukrywa ekran ładowania. Do wykorzystania z <c>using</c>.
		/// </returns>
		IDisposable ShowLoadingScreen();
	}
}
