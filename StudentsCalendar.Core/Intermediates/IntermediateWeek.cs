using System.Collections.Generic;
using NodaTime;

namespace StudentsCalendar.Core.Intermediates
{
	/// <summary>
	/// Opis tygodnia - dane pośredniczące.
	/// </summary>
	public sealed class IntermediateWeek
	{
		private readonly LocalDate _Date;

		/// <summary>
		/// Pobiera datę tygodnia, który dany obiekt opisuje.
		/// </summary>
		/// <remarks>
		/// Data wskazuje na poniedziałek w danym tygodniu.
		/// </remarks>
		public LocalDate Date
		{
			get { return this._Date; }
		}

		/// <summary>
		/// Pobiera lub zmienia listę szablonów.
		/// </summary>
		/// <remarks>
		/// Szablon na dany dzień tygodnia znajduje się pod indeksem zwracanym przez <c>IsoDayOfWeek.ToIndex()</c>.
		/// </remarks>
		public IList<IntermediateDay> Days { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt, ustawiając tydzień, który opisuje.
		/// </summary>
		/// <param name="date"></param>
		public IntermediateWeek(LocalDate date)
		{
			this._Date = date;
		}
	}
}
