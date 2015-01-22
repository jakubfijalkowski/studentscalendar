using System.Collections.Generic;
using NodaTime;
using StudentsCalendar.Core.Finals;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// Klasa odpowiadająca za zaaranżowanie układu dnia tak, by żadne dwa zajęcia
	/// się nie pokrywały.
	/// </summary>
	/// <remarks>
	/// Przyjmuje się podział na sloty, gdzie każdy slot oznacza jedną godzinę.
	/// </remarks>
	public interface ILayoutArranger
	{
		/// <summary>
		/// Układa zajęcia tak, by można je było bez przeszkód wyświetlić.
		/// </summary>
		/// <param name="day"></param>
		/// <param name="fromWeek"></param>
		ArrangedDay Arrange(FinalDay day, FinalWeek fromWeek);

		/// <summary>
		/// Układa tygodniowy rozkład zajęć tak, by można go było bez przeszkód
		/// wyświetlić. Układa poszczególne dni i normalizuje ilość slotów.
		/// </summary>
		/// <param name="week"></param>
		/// <returns></returns>
		ArrangedWeek Arrange(FinalWeek week);
	}

	/// <summary>
	/// Opisuje zajęcia ułożone na tablicy zajęć.
	/// </summary>
	public sealed class ArrangedClasses
	{
		private readonly FinalClasses _Classes;
		private readonly double _StartSlot;
		private readonly double _EndSlot;

		/// <summary>
		/// Pobiera zajęcia opisane przez ten obiekt.
		/// </summary>
		public FinalClasses Classes
		{
			get { return this._Classes; }
		}

		/// <summary>
		/// Pobiera slot, w którym dane zajęcia się rozpoczynają.
		/// </summary>
		public double StartSlot
		{
			get { return this._StartSlot; }
		}

		/// <summary>
		/// Pobiera slot, w którym dane zajęcia się kończą.
		/// </summary>
		public double EndSlot
		{
			get { return this._EndSlot; }
		}

		/// <summary>
		/// Inicjalizuje obiekt.
		/// </summary>
		/// <param name="classes"></param>
		/// <param name="startSlot"></param>
		/// <param name="endSlot"></param>
		public ArrangedClasses(FinalClasses classes, double startSlot, double endSlot)
		{
			this._Classes = classes;
			this._StartSlot = startSlot;
			this._EndSlot = endSlot;
		}
	}

	/// <summary>
	/// Opis pełnego dnia.
	/// </summary>
	public sealed class ArrangedDay
	{
		private readonly FinalDay _Day;
		private readonly IReadOnlyList<LocalTime> _Slots;
		private readonly IReadOnlyList<IReadOnlyList<ArrangedClasses>> _Columns;

		/// <summary>
		/// Pobiera dzień opisywany przez ten obiekt.
		/// </summary>
		public FinalDay Day
		{
			get { return this._Day; }
		}

		/// <summary>
		/// Pobiera listę slotów.
		/// </summary>
		public IReadOnlyList<LocalTime> Slots
		{
			get { return this._Slots; }
		}

		/// <summary>
		/// Pobiera listę kolumn
		/// </summary>
		public IReadOnlyList<IReadOnlyList<ArrangedClasses>> Columns
		{
			get { return this._Columns; }
		}

		/// <summary>
		/// Inicjalizuje obiekt.
		/// </summary>
		/// <param name="day"></param>
		/// <param name="slots"></param>
		/// <param name="columns"></param>
		public ArrangedDay(FinalDay day, IReadOnlyList<LocalTime> slots, IReadOnlyList<IReadOnlyList<ArrangedClasses>> columns)
		{
			this._Day = day;
			this._Slots = slots;
			this._Columns = columns;
		}
	}

	/// <summary>
	/// Opis pełnego tygodnia.
	/// </summary>
	public sealed class ArrangedWeek
	{
		private readonly FinalWeek _Week;
		private readonly IReadOnlyList<ArrangedDay> _Days;

		/// <summary>
		/// Pobiera dane tygodnia, któru opisuje.
		/// </summary>
		public FinalWeek Week
		{
			get { return this._Week; }
		}

		/// <summary>
		/// Pobiera listę opisów poszczególnych dni.
		/// </summary>
		/// <remarks>
		/// Konwencja dostępu taka sama jak w <see cref="FinalWeek.Days"/>.
		/// </remarks>
		public IReadOnlyList<ArrangedDay> Days
		{
			get { return this._Days; }
		}

		/// <summary>
		/// Inicjalizuje obiekt.
		/// </summary>
		/// <param name="week"></param>
		/// <param name="days"></param>
		public ArrangedWeek(FinalWeek week, IReadOnlyList<ArrangedDay> days)
		{
			this._Week = week;
			this._Days = days;
		}
	}
}
