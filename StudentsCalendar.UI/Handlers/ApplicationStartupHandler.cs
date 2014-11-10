using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.UI.Events;

namespace StudentsCalendar.UI.Handlers
{
	/// <summary>
	/// Obsługuje <see cref="ApplicationStartedEvent"/>.
	/// Ładuje dane startowe, przygotowuje ekran startowy i wyświetla go.
	/// </summary>
	public sealed class ApplicationStartupHandler
		: IHandle<ApplicationStartedEvent>
	{
		private readonly ICalendarsManager Calendars;
		private readonly IShell Shell;
		private readonly IEventAggregator EventAggregator;

		public ApplicationStartupHandler(ICalendarsManager calendars, IShell shell, IEventAggregator eventAggregator)
		{
			this.Calendars = calendars;
			this.Shell = shell;
			this.EventAggregator = eventAggregator;
		}

		public async void Handle(ApplicationStartedEvent message)
		{
			using (this.Shell.ShowLoadingScreen())
			{
				await this.Calendars.Initialize();
			}

			this.EventAggregator.PublishOnUIThread(NavigateRequestEvent.Create<Main.CurrentWeekViewModel>());
		}
	}
}
