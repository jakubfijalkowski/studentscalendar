using System;
using Caliburn.Micro;
using StudentsCalendar.UI;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// "Shell" aplikacji desktopowej - używa kart do prezentacji głównych
	/// elementów oraz okien dialogowych(wew. aplikacji) do prezentacji
	/// "podekranów".
	/// </summary>
	sealed class ShellViewModel
		: Conductor<object>.Collection.AllActive, IShell
	{
		/// <summary>
		/// Pobiera kontrolkę z kartami dla widoku.
		/// </summary>
		public TabsViewModel TabsControl
		{
			get { return (TabsViewModel)this.Items[0]; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="tabs"></param>
		public ShellViewModel(TabsViewModel tabs)
		{
			this.ActivateItem(tabs);
		}

		/// <inheritdoc />
		public void NavigateTo<TViewModel>()
		{
			throw new NotImplementedException();
		}
	}
}
