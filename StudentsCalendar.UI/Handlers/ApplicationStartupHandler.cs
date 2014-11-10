using Caliburn.Micro;
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
		private readonly IEventAggregator EventAggregator;

		public ApplicationStartupHandler(IEventAggregator eventAggregator)
		{
			this.EventAggregator = eventAggregator;
		}

		public void Handle(ApplicationStartedEvent message)
		{
			this.EventAggregator.PublishOnUIThread(NavigateRequestEvent.Create<Main.CurrentWeekViewModel>());
		}
	}
}
