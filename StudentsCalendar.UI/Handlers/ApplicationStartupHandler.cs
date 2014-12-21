using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.UI.Dialogs;
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
		private readonly ICurrentCalendar CurrentCalendar;
		private readonly IShell Shell;

		public ApplicationStartupHandler(ICalendarsManager calendars, ICurrentCalendar currentCalendar,
			IShell shell)
		{
			this.Calendars = calendars;
			this.CurrentCalendar = currentCalendar;
			this.Shell = shell;
		}

		public async void Handle(ApplicationStartedEvent message)
		{
			using (this.Shell.ShowLoadingScreen())
			{
				var initResult = await this.TryInitialize();
				if (initResult.Item1 != null)
				{
					await this.Shell.ShowDialog(initResult.Item1);
				}
				Execute.OnUIThread(() => this.Shell.ShowMainScreen(initResult.Item2));
			}
		}

		private async Task<Tuple<object, Type>> TryInitialize()
		{
			object dialog = null;
			Type destScreen = typeof(Main.CurrentWeekViewModel);
			do
			{
				try
				{
					await this.Calendars.Initialize();
				}
				catch
				{
					dialog = new ErrorDialog
					{
						Title = "Wystąpił błąd",
						Message = "Nie udało się wczytać istniejących kalendarzy(błąd systemowy). Jeśli nie chcesz stracić danych, zalecamy wyłącznie aplikacji i rozwiązanie błędu."
					};
					destScreen = typeof(Main.CalendarsViewModel);
					break;
				}

				if (this.Calendars.ActiveEntry == null)
				{
					dialog = new InformationDialog
					{
						Title = "Brak aktywnego kalendarza",
						Message = "Aktualny kalendarz nie został wybrany. Przed rozpoczęciem korzystania z aplikacji należy utworzyć szablon kalendarza i wskazać go jako aktualny."
					};
					destScreen = typeof(Main.CalendarsViewModel);
					break;
				}
				try
				{
					await this.CurrentCalendar.MakeActive(this.Calendars.ActiveEntry.Id);
				}
				catch
				{
					dialog = new ErrorDialog
					{
						Title = "Wystąpił błąd",
						Message = "Nie udało się wczytać aktywnego kalendarza(błąd systemowy). Jeśli nie chcesz stracić danych, zalecamy wyłącznie aplikacji i rozwiązanie błędu."
					};
					destScreen = typeof(Main.CalendarsViewModel);
					break;
				}
			} while (false);
			return Tuple.Create(dialog, destScreen);
		}
	}
}
