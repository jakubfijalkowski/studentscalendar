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
		/// Pobiera kontrolkę obsługującą okna aplikacji.
		/// </summary>
		public WindowsViewModel WindowsControl
		{
			get { return (WindowsViewModel)this.Items[1]; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="tabs"></param>
		/// <param name="windows"></param>
		public ShellViewModel(TabsViewModel tabs, WindowsViewModel windows)
		{
			this.ActivateItem(tabs);
			this.ActivateItem(windows);
		}

		/// <inheritdoc />
		public TViewModel NavigateTo<TViewModel>()
		{
			var model = IoC.Get<TViewModel>();
			this.WindowsControl.ActivateItem(model);
			return model;
		}
	}
}
