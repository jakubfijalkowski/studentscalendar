using System;
using Autofac.Features.Indexed;
using Caliburn.Micro;
using StudentsCalendar.UI;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// "Shell" aplikacji desktopowej.
	/// </summary>
	sealed class ShellViewModel
		: Conductor<object>.Collection.AllActive, IShell, IHandle<UI.Events.NavigateRequestEvent>
	{
		private readonly IIndex<Type, IViewModel> ViewModelsFactory;
		private readonly IEventAggregator EventAggregator;

		private bool _IsLoading;

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
		/// Określa, czy aplikacja jest w stanie "ładowania" i powinien
		/// być wyświetlony odpowiedni ekran.
		/// </summary>
		public bool IsLoading
		{
			get { return this._IsLoading; }
			private set
			{
				if (this._IsLoading != value)
				{
					this._IsLoading = value;
					this.NotifyOfPropertyChange();
				}
			}
		}


		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="mainScreen"></param>
		/// <param name="popups"></param>
		/// <param name="viewModelsFactory"></param>
		/// <param name="eventAggregator"></param>
		public ShellViewModel(MainScreenViewModel mainScreen, PopupsViewModel popups,
			IIndex<Type, IViewModel> viewModelsFactory, IEventAggregator eventAggregator)
		{
			this.ViewModelsFactory = viewModelsFactory;
			this.EventAggregator = eventAggregator;

			this.ActivateItem(mainScreen);
			this.ActivateItem(popups);
		}

		/// <summary>
		/// Wyświetla widok aktualnego tygodnia.
		/// </summary>
		/// TODO: consider moving to NavigationRequestEvent
		public void ShowCurrentWeek()
		{
			this.ShowMainScreen(typeof(UI.Main.CurrentWeekViewModel));
		}

		/// <summary>
		/// Wyświetla widok aktualnego miesiąca.
		/// </summary>
		public void ShowMonth()
		{
			this.ShowMainScreen(typeof(UI.Main.MonthViewModel));
		}

		/// <summary>
		/// Wyświetla widok kalendarzy.
		/// </summary>
		public void ShowCalendars()
		{
			this.ShowMainScreen(typeof(UI.Main.CalendarsViewModel));
		}

		/// <inheritdoc />
		public void Handle(UI.Events.NavigateRequestEvent message)
		{
			this.ShowMainScreen(message.ScreenType);
		}

		/// <inheritdoc />
		public TViewModel Show<TViewModel>()
			where TViewModel : IViewModel
		{
			var model = (TViewModel)this.ViewModelsFactory[typeof(TViewModel)];
			this.PopupsControl.ActivateItem(model);
			return model;
		}

		/// <inheritdoc />
		public IDisposable ShowLoadingScreen()
		{
			//TODO: consider making it multithreaded and ref-counted
			return new LoadingDisposable(this);
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			this.EventAggregator.Subscribe(this);
		}

		protected override void OnDeactivate(bool close)
		{
			base.OnDeactivate(close);
			if (close)
			{
				this.EventAggregator.Unsubscribe(this);
			}
		}

		private void ShowMainScreen(Type mainScreenType)
		{
			var model = this.ViewModelsFactory[mainScreenType];
			this.MainScreen.ActivateItem(model);
			//TODO: remove all popups
		}

		private sealed class LoadingDisposable
			: IDisposable
		{
			private readonly ShellViewModel Parent;

			public LoadingDisposable(ShellViewModel parent)
			{
				this.Parent = parent;
				this.Parent.IsLoading = true;
			}

			public void Dispose()
			{
				this.Parent.IsLoading = false;
			}
		}
	}
}
