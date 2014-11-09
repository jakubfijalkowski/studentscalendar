using System.Windows;

namespace StudentsCalendar.Desktop
{
	static class BooleanExtensions
	{
		/// <summary>
		/// Konwertuje <c>true</c> na <see cref="Visibility.Visible"/> i
		/// <c>false</c> na <see cref="Visibility.Collapsed"/>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Visibility ToVisibility(this bool value)
		{
			return value ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
