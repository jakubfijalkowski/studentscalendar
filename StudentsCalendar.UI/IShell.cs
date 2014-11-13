using System;
using System.Threading.Tasks;

namespace StudentsCalendar.UI
{
	/// <summary>
	/// Główny obiekt aplikacji - obsługuje nawigację w ramach aplikacji.
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
		/// <remarks>
		/// Metoda ta może zarówno podmieniać ekran(Windows Phone) jak i wyświetlać
		/// ekran, przykrywający główny ekran aplikacji.
		/// 
		/// Jeśli <typeparamref name="TViewModel"/> implementuje interfejs <see cref="IHaveContext{TData}"/>,
		/// obiekt wywołujący tą metodę jest odpowiedzialny za wywołanie <see cref="IHaveContext{TData}.UpdateContext"/>.
		/// </remarks>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns>Utworzony ViewModel.</returns>
		TViewModel ShowPopup<TViewModel>()
			where TViewModel : IViewModel;

		/// <summary>
		/// Wyświetla okno dialogowe o wskazanym typie modelu.
		/// Zobacz <see cref="IDialogView"/> po więcej informacji na temat dialogów.
		/// </summary>
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
