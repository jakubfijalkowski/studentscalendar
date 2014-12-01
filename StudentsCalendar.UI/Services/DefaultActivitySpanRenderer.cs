using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using StudentsCalendar.Core.ActivitySpans;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// Wyświetla wbudowane przedziały aktywności.
	/// </summary>
	public sealed class DefaultActivitySpanRenderer
		: IActivitySpanRenderer
	{
		private readonly Dictionary<Type, MethodInfo> Descriptions;

		public DefaultActivitySpanRenderer()
		{
			this.Descriptions = typeof(DefaultActivitySpanRenderer)
				.GetRuntimeMethods()
				.Where(m => m.Name == "Describe")
				.ToDictionary(m => m.GetParameters()[0].ParameterType);
		}

		/// <inheritdoc />
		public string Describe(IActivitySpan span)
		{
			return (string)this.Descriptions[span.GetType()]
				.Invoke(this, new object[] { span });
		}

		private string Describe(AlwaysExceptActivitySpan span)
		{
			var dates = span.Dates.Select(d => d.ToString("D", CultureInfo.CurrentCulture));
			return "zawsze oprócz " + string.Join(", ", dates);
		}

		private string Describe(DateRangeActivitySpan span)
		{
			return string.Format(CultureInfo.CurrentCulture, "od {0:D} do {1:D}", span.Beginning, span.End);
		}

		private string Describe(EmptyActivitySpan span)
		{
			return "nigdy";
		}

		private string Describe(EveryXMonthsActivitySpan span)
		{
			var str = string.Format("co {0} {1}", span.Count, PluralForm(span.Count, "miesiąc", "miesięcy", "miesiące"));
			if (span.StartDate.HasValue)
			{
				str += " począwszy od " + span.StartDate.Value.ToString("D", CultureInfo.CurrentCulture);
			}
			return str;
		}

		private string Describe(EveryXWeeksActivitySpan span)
		{
			var str = string.Format("co {0} {1}", span.Count, PluralForm(span.Count, "tydzień", "tygodni", "tygodnie"));
			if (span.StartDate.HasValue)
			{
				str += " począwszy od " + span.StartDate.Value.ToString("D", CultureInfo.CurrentCulture);
			}
			return str;
		}

		private string Describe(FullActivitySpan span)
		{
			return "zawsze";
		}

		private string Describe(SpecificDatesActivitySpan span)
		{
			var dates = span.Dates.Select(d => d.ToString("D", CultureInfo.CurrentCulture));
			return "tylko " + string.Join(", ", dates);
		}

		private string Describe(SpecificWeeksActivitySpan span)
		{
			var dates = span.Dates
				.Select(d => new { Start = d, End = d.Next(NodaTime.IsoDayOfWeek.Sunday) })
				.Select(d => new { Start = d.Start.ToString("D", CultureInfo.CurrentCulture), End = d.End.ToString("D", CultureInfo.CurrentCulture) })
				.Select(d => d.Start + " - " + d.End);
			return "tylko " + string.Join(", ", dates);
		}

		private static string PluralForm(int count, string singular, string plural, string plural24)
		{
			if (count == 1)
			{
				return singular;
			}
			else if (count % 10 < 2 || count % 10 >= 5 || (count >= 12 && count < 15))
			{
				return plural;
			}
			return plural24;
		}
	}
}
