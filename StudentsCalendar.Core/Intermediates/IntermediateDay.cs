using System.Collections.Generic;
using NodaTime;

namespace StudentsCalendar.Core.Intermediates
{
	/// <summary>
	/// Opis dnia - dane pośredniczące.
	/// </summary>
	public sealed class IntermediateDay
	{
		private readonly LocalDate _Date;

		/// <summary>
		/// Pobiera datę, który dany obiekt opisuje.
		/// </summary>
		public LocalDate Date
		{
			get { return this._Date; }
		}

		/// <summary>
		/// Pobiera lub zmienia listę zajęć danego dnia.
		/// </summary>
		public IList<IntermediateClasses> Classes { get; set; }

		/// <summary>
		/// Pobiera lub zmienia notatki.
		/// </summary>
		public string Notes { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt ustawiając datę, którą opisuje.
		/// </summary>
		public IntermediateDay(LocalDate date)
		{
			this._Date = date;
		}
	}
}
