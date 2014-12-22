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
		/// Pobiera lub zmienia kolekcję wybranych dat.
		/// </summary>
		IEnumerable<DateTime> Dates { get; set; }
	}

	/// <summary>
	/// Bazowy ViewModel dla przedziałów, które operują na przedziałach dat.
	/// </summary>
	/// <typeparam name="TViewModel"></typeparam>
	public abstract class BaseDatesSpanViewModel<TViewModel>
		: BaseActivitySpanViewModel<TViewModel>, IBaseDatesSpanViewModel
		where TViewModel : class, IActivitySpan
	{
		/// <summary>
		/// Pobiera lub zmienia kolekcję wybranych dat(jako <see cref="DateTime"/>).
		/// </summary>
		public IEnumerable<DateTime> Dates
		{
			get
			{
				return this.InternalDates.Select(d => new DateTime(d.Year, d.Month, d.Day));
			}
			set
			{
				this.InternalDates = value.Select(d => new LocalDate(d.Year, d.Month, d.Day)).ToList();
			}
		}

		/// <summary>
		/// Pobiera lub zmienia właściwą listę wybranych dat(jako <see cref="LocalDate"/>).
		/// </summary>
		protected abstract IList<LocalDate> InternalDates { get; set; }

		protected BaseDatesSpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}
}
