using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Logging;
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
		private readonly ILogger Logger;

		public ApplicationStartupHandler(ICalendarsManager calendars, ICurrentCalendar currentCalendar,
			IShell shell, ILogger logger)
		{
			this.Calendars = calendars;
			this.CurrentCalendar = currentCalendar;
			this.Shell = shell;
			this.Logger = logger;
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
				catch (Exception ex)
				{
					this.Logger.Error(ex, "Cannot initialize ICurrentCalendar.");

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
					this.Logger.Error("There is no active calendar.");

					dialog = new InformationDialog
					{
						Title = "Brak aktywnego kalendarza",
						Message = "Aktualny kalendarz nie został wybrany. Przed rozpoczęciem korzystania z aplikacji należy utworzyć szablon kalendarza i wskazać go jako aktualny."
					};
					destScreen = typeof(Main.CalendarsViewModel);
					break;
				}

				if (!this.IsCurrentCalendarValid())
				{
					this.Logger.Error("Current calendar is outdated.");

					dialog = new InformationDialog
					{
						Title = "Kalendarz jest nieaktualny",
						Message = "Wybrany kalendarz jest nieaktualny. Zaktualizuj go, lub stwórz nowy."
					};
					destScreen = typeof(Main.CalendarsViewModel);
					break;
				}

				try
				{
					await this.CurrentCalendar.MakeActive(this.Calendars.ActiveEntry.Id);
				}
				catch (Exception ex)
				{
					this.Logger.Error(ex, "Cannot make current calendar active.");

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

		private bool IsCurrentCalendarValid()
		{
			var today = DateHelper.Today;
			return this.Calendars.ActiveEntry.StartDate <= today && this.Calendars.ActiveEntry.EndDate >= today;
		}
	}
}
