﻿using System.Collections.Generic;
using System.Linq;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Operacja iloczynu przedziałów.
	/// </summary>
	public sealed class WeekActivitySpanProduct
		: IWeekActivitySpan
	{
		/// <summary>
		/// Pobiera listę podprzedziałów.
		/// </summary>
		public IList<IWeekActivitySpan> Spans { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt pustą listą.
		/// </summary>
		public WeekActivitySpanProduct()
		{
			this.Spans = new List<IWeekActivitySpan>();
		}

		/// <inheritdoc />
		public bool IsWeekActive(NodaTime.LocalDate baseDate, NodaTime.LocalDate date)
		{
			return this.Spans.All(s => s.IsWeekActive(baseDate, date));
		}
	}
}