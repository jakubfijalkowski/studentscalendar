using Caliburn.Micro;

namespace StudentsCalendar.UI.Handlers
{
	/// <summary>
	/// Obsługuje <see cref="Events.NavigateRequestEvent"/>.
	/// </summary>
	public sealed class NavigationHandler
		: IHandle<Events.NavigateRequestEvent>
	{
		private readonly IShell Shell;

		public NavigationHandler(IShell shell)
		{
			this.Shell = shell;
		}

		public void Handle(Events.NavigateRequestEvent message)
		{
			this.Shell.ShowMainScreen(message.ScreenType);
		}
	}
}
