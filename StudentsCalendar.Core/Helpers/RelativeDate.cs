using NodaTime;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Metody pomocne przy obliczaniu dat relatywnych.
	/// </summary>
	public static class RelativeDate
	{
		/// <summary>
		/// Oblicza datę bazową dla tygodnia.
		/// </summary>
		/// <param name="week"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		public static LocalDate CalculateBaseDateWith(this IntermediateWeek week, GenerationContext context)
		{
			return context.StartDate;
		}

		/// <summary>
		/// Oblicza datę bazową dla dnia.
		/// </summary>
		/// <param name="day"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		public static LocalDate CalculateBaseDateWith(this IntermediateDay day, GenerationContext context)
		{
			return CalculateBaseDateForDay(context, day.Date.IsoDayOfWeek);
		}

		/// <summary>
		/// Oblicza date bazową dla zajęć.
		/// </summary>
		/// <param name="classes"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		public static LocalDate CalculateBaseDateWith(this IntermediateClasses classes, GenerationContext context)
		{
			return CalculateBaseDateForDay(context, classes.StartDate.IsoDayOfWeek);
		}

		private static LocalDate CalculateBaseDateForDay(GenerationContext context, IsoDayOfWeek dayOfWeek)
		{
			if (dayOfWeek != IsoDayOfWeek.Monday)
			{
				return context.StartDate.Next(dayOfWeek);
			}
			return context.StartDate;
		}
	}
}
