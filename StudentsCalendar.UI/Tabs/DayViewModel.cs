using Caliburn.Micro;
using NodaTime;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Tabs
{
	/// <summary>
	/// ViewModel karty widoku dnia.
	/// </summary>
	public sealed class DayViewModel
		: Screen, IMainTab
	{
		private readonly ILayoutArranger LayoutArranger;

		/// <inheritdoc />
		public int Priority
		{
			get { return 0; }
		}

		/// <summary>
		/// Pobiera ułożony layout dzienny.
		/// </summary>
		public ArrangedDay DayLayout { get; private set; }

		/// <summary>
		/// Inicjalizuje obiekt.
		/// </summary>
		public DayViewModel(ILayoutArranger layoutArranger)
		{
			this.LayoutArranger = layoutArranger;

			this.DisplayName = "Dzień";
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			var sampleClasses = new FinalClasses(DateHelper.Today.At(new LocalTime(9, 0)), DateHelper.Today.At(new LocalTime(10, 0)),
				"MNII", "Metody numeryczne II", new FinalLecturer("Adam", "Grabarski", ""), new FinalLocation("MiNI", "Koszykowa 75", "123"), "");
			this.DayLayout = this.LayoutArranger.Arrange(new FinalDay(DateHelper.Today, new FinalClasses[]
				{
					sampleClasses
				}, string.Empty));
		}
	}
}
