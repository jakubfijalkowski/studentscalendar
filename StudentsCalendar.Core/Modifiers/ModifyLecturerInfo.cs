using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Zmienia informacje o prowadzącym.
	/// </summary>
	public class ModifyLecturerInfo
		: IClassesModifier
	{
		/// <summary>
		/// Pobiera lub zmienia imię nowej lokalizacji.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Pobiera lub zmienia nazwisko nowej lokalizacji.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Pobiera lub zmienia nowy numer kontaktowy.
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <inheritdoc />
		public IActivitySpan ActivitySpan { get; set; }

		/// <inheritdoc />
		public virtual IntermediateClasses Apply(IntermediateClasses data, GenerationContext context)
		{
			data.Lecturer.FirstName = this.FirstName ?? data.Lecturer.FirstName;
			data.Lecturer.LastName = this.LastName ?? data.Lecturer.LastName;
			data.Lecturer.PhoneNumber = this.PhoneNumber ?? data.Lecturer.PhoneNumber;
			return data;
		}
	}
}
