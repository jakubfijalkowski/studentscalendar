using System;

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
		/// <param name="mainScreenType"></param>
		void ShowMainScreen(Type mainScreenType);

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
