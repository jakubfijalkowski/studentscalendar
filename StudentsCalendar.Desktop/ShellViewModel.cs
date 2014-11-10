using Caliburn.Micro;
using StudentsCalendar.UI;

using MainScreenViewModel = Caliburn.Micro.Conductor<StudentsCalendar.UI.IMainScreen>.Collection.OneActive;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// "Shell" aplikacji desktopowej.
	/// </summary>
	sealed class ShellViewModel
		: Conductor<object>.Collection.OneActive, IShell
	{
		/// <summary>
		/// Pobiera kontrolkę z głównym widokiem.
		/// </summary>
		public MainScreenViewModel MainScreen
		{
			get { return (MainScreenViewModel)this.Items[0]; }
		}

		/// <summary>
		/// Pobiera kontrolkę obsługującą okna aplikacji.
		/// </summary>
		public PopupsViewModel PopupsControl
		{
			get { return (PopupsViewModel)this.Items[1]; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="popups"></param>
		public ShellViewModel(PopupsViewModel popups)
		{
			this.ActivateItem(new MainScreenViewModel());
			this.ActivateItem(popups);
		}

		/// <inheritdoc />
		public TViewModel NavigateTo<TViewModel>()
			where TViewModel : IMainScreen
		{
			var model = IoC.Get<TViewModel>();
			this.MainScreen.ActivateItem(model);
			return model;
		}

		/// <inheritdoc />
		public TViewModel Show<TViewModel>() where TViewModel : IPopupScreen
		{
			var model = IoC.Get<TViewModel>();
			this.PopupsControl.ActivateItem(model);
			return model;
		}
	}
}
