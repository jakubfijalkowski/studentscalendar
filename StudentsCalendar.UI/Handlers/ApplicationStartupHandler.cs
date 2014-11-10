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
		private readonly IEventAggregator EventAggregator;

		public ApplicationStartupHandler(ICalendarsManager calendars, IEventAggregator eventAggregator)
		{
			this.Calendars = calendars;
			this.EventAggregator = eventAggregator;
		}

		public async void Handle(ApplicationStartedEvent message)
		{
			//TODO: display loading screen
			await this.Calendars.Initialize();

			this.EventAggregator.PublishOnUIThread(NavigateRequestEvent.Create<Main.CurrentWeekViewModel>());
		}
	}
}
