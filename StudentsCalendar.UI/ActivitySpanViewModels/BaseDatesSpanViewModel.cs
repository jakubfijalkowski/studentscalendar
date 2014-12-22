using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	/// <summary>
	/// Interfejs uproszczający kod. Właściwą klasą jest <see cref="BaseDatesSpanViewModel{TViewModel}"/>.
	/// </summary>
	public interface IBaseDatesSpanViewModel
	{
		/// <summary>
		/// Pobiera listę wybranych dat.
		/// </summary>
		IEnumerable<DateTime> Dates { get; }

		/// <summary>
		/// Aktualizuje wybrane daty.
		/// </summary>
		/// <param name="dates"></param>
		/// <returns>Zwraca <c>true</c>, jeśli kolekcja dat została zmieniona.</returns>
		bool UpdateDates(IEnumerable<DateTime> dates);
	}

	/// <summary>
	/// Bazowy ViewModel dla przedziałów, które operują na przedziałach dat.
	/// </summary>
	/// <typeparam name="TViewModel"></typeparam>
	public abstract class BaseDatesSpanViewModel<TViewModel>
		: BaseActivitySpanViewModel<TViewModel>, IBaseDatesSpanViewModel
		where TViewModel : class, IActivitySpan
	{
		/// <inheritdoc />
		public IEnumerable<DateTime> Dates
		{
			get
			{
				if (this.IsWeeklyModel)
				{
					return this.InternalDates.SelectMany(ToWholeWeek);
				}
				else
				{
					return this.InternalDates.Select(d => new DateTime(d.Year, d.Month, d.Day));
				}
			}
		}

		/// <summary>
		/// Pobiera lub zmienia właściwą listę wybranych dat(jako <see cref="LocalDate"/>).
		/// </summary>
		protected abstract IList<LocalDate> InternalDates { get; set; }

		/// <summary>
		/// Określa, czy ViewModel pracuje na tygodniach, czy na pojedynczych dniach.
		/// </summary>
		protected virtual bool IsWeeklyModel
		{
			get { return false; }
		}

		protected BaseDatesSpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }

		public bool UpdateDates(IEnumerable<DateTime> dates)
		{
			var converted = dates
				.Select(d => new LocalDate(d.Year, d.Month, d.Day));

			if (this.IsWeeklyModel)
			{
				converted = converted
					.Select(d => d.IsoDayOfWeek != IsoDayOfWeek.Monday ? d.Previous(IsoDayOfWeek.Monday) : d)
					.Distinct();
			}

			this.InternalDates = converted.OrderBy(d => d).ToList();

			return this.IsWeeklyModel;
		}

		private IEnumerable<DateTime> ToWholeWeek(LocalDate date)
		{
			for (int i = 0; i < 7; i++)
			{
				var d = date.PlusDays(i);
				yield return new DateTime(d.Year, d.Month, d.Day);
			}
		}
	}
}
