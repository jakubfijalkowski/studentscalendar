using Caliburn.Micro;
using StudentsCalendar.UI.Events;

namespace StudentsCalendar.UI.Handlers
{
	/// <summary>
	/// Obsługuje <see cref="NavigateRequestEvent"/> wywołując odpowiednią metodę <see cref="IShell"/>a.
	/// </summary>
	public sealed class NavigationRequestHandler
		: IHandle<NavigateRequestEvent>
	{
		private readonly IShell Shell;

		public NavigationRequestHandler(IShell shell)
		{
			this.Shell = shell;
		}

		/// <inheritdoc />
		public void Handle(NavigateRequestEvent message)
		{
			this.Shell.ShowMainScreen(message.ScreenType);
		}
	}
}
