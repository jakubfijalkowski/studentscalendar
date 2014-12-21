using System;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Priorytet testu dodawanego przez modyfikator <see cref="AddTestToClasses"/>.
	/// </summary>
	public enum TestPriority
	{
		Low,
		Normal,
		High
	}

	/// <summary>
	/// Dodaje informacje o teście do notatek zajęć.
	/// </summary>
	public sealed class AddTestToClasses
		: IClassesModifier
	{
		/// <summary>
		/// Pobiera lub zmienia tytuł sprawdzianu.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Pobiera lub zmienia dodatkowe informacje o teście.
		/// </summary>
		public string Information { get; set; }

		/// <summary>
		/// Pobiera lub zmienia priorytet testu.
		/// </summary>
		/// <remarks>
		/// Priorytet decyduje, gdzie test jest dodawany i jaką ma strukturę.
		/// 
		/// * Niski priorytet - na końcu notatek.
		/// * Normalny priorytet - na początku, nie wytłuszczony.
		/// * Wysoki priorytet - wytłuszczony, na początku notatek.
		/// </remarks>
		public TestPriority Priority { get; set; }

		/// <inheritdoc />
		public IDailyActivitySpan ActivitySpan { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt domyślnymi wartościami.
		/// </summary>
		public AddTestToClasses()
		{
			this.ActivitySpan = new EmptyActivitySpan();
		}

		/// <inheritdoc />
		public IntermediateClasses Apply(IntermediateClasses data, GenerationContext context)
		{
			string notes = data.Notes ?? string.Empty;
			switch (this.Priority)
			{
				case TestPriority.Low:
					notes += this.Title + Environment.NewLine + this.Information;
					break;
				case TestPriority.Normal:
					notes = this.Title + Environment.NewLine +
						this.Information + Environment.NewLine +
						notes;
					break;
				case TestPriority.High:
					notes = this.Title.ToUpper() + Environment.NewLine +
						this.Information + Environment.NewLine +
						notes;
					break;
			}
			data.Notes = notes;
			return data;
		}
	}
}
