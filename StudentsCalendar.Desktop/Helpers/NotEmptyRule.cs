using System.Windows.Controls;

namespace StudentsCalendar.Desktop.Helpers
{
	/// <summary>
	/// Zabrania wartości(tekstowej) być pustej.
	/// </summary>
	public sealed class NotEmptyRule
		: ValidationRule
	{
		/// <summary>
		/// Wskazuje, czy pozwalać na ciągi złożone z samych białych znaków.
		/// </summary>
		public bool AllowWhitespaces { get; set; }

		public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
		{
			bool isValid = this.AllowWhitespaces ? !string.IsNullOrEmpty((string)value) : !string.IsNullOrWhiteSpace((string)value);
			return new ValidationResult(isValid, isValid ? null : "Wartość nie może być pusta.");
		}
	}
}
