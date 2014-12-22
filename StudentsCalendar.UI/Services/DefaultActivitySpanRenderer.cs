﻿using System;
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
	/// <remarks>
	/// Używa <see cref="IActivitySpanViewLocator"/> i <see cref="Activator"/> do stworzenia
	/// i zbindowania widoku dla <see cref="ActivitySpan"/>.
	/// </remarks>
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
		public string Describe(IActivitySpan span, bool shouldBeUniversal = false)
		{
			return (string)this.Descriptions[span.GetType()]
				.Invoke(this, new object[] { span, shouldBeUniversal });
		}

		private string Describe(AlwaysExceptActivitySpan span, bool shouldBeUniversal)
		{
			if (shouldBeUniversal)
			{
				return "zawsze oprócz ...";
			}
			var dates = span.Dates.Select(d => d.ToString("D", CultureInfo.CurrentCulture));
			return "zawsze oprócz " + string.Join(", ", dates);
		}

		private string Describe(DateRangeActivitySpan span, bool shouldBeUniversal)
		{
			if (shouldBeUniversal)
			{
				return "od ... do ...";
			}
			return string.Format(CultureInfo.CurrentCulture, "od {0:D} do {1:D}", span.Beginning, span.End);
		}

		private string Describe(EmptyActivitySpan span, bool shouldBeUniversal)
		{
			return "nigdy";
		}

		private string Describe(EveryXMonthsActivitySpan span, bool shouldBeUniversal)
		{
			if (shouldBeUniversal)
			{
				return "co X miesięcy";
			}

			var str = string.Format("co {0} {1}", span.Count, PluralForm(span.Count, "miesiąc", "miesięcy", "miesiące"));
			if (span.StartDate.HasValue)
			{
				str += " począwszy od " + span.StartDate.Value.ToString("D", CultureInfo.CurrentCulture);
			}
			return str;
		}

		private string Describe(EveryXWeeksActivitySpan span, bool shouldBeUniversal)
		{
			if (shouldBeUniversal)
			{
				return "co X tygodni";
			}

			var str = string.Format("co {0} {1}", span.Count, PluralForm(span.Count, "tydzień", "tygodni", "tygodnie"));
			if (span.StartDate.HasValue)
			{
				str += " począwszy od " + span.StartDate.Value.ToString("D", CultureInfo.CurrentCulture);
			}
			return str;
		}

		private string Describe(FullActivitySpan span, bool shouldBeUniversal)
		{
			return "zawsze";
		}

		private string Describe(SpecificDatesActivitySpan span, bool shouldBeUniversal)
		{
			if (shouldBeUniversal)
			{
				return "tylko w określone dni";
			}

			var dates = span.Dates.Select(d => d.ToString("D", CultureInfo.CurrentCulture));
			return "tylko " + string.Join(", ", dates);
		}

		private string Describe(SpecificWeeksActivitySpan span, bool shouldBeUniversal)
		{
			if (shouldBeUniversal)
			{
				return "tylko w określone tygodnie";
			}

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
