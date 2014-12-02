using StudentsCalendar.Core.ActivitySpans;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// Odpowiada za wyświetlanie przedziałów aktywności w sposób strawny
	/// dla użytkownika.
	/// </summary>
	public interface IActivitySpanRenderer
	{
		/// <summary>
		/// Opisuje wskazany przedział aktywności.
		/// </summary>
		/// <param name="span"></param>
		/// <param name="shouldBeUniversal"></param>
		/// <returns></returns>
		string Describe(IActivitySpan span, bool shouldBeUniversal = false);

		/// <summary>
		/// Tworzy kontrolkę UI dla wskazanego przedziału aktywności.
		/// </summary>
		/// <param name="span"></param>
		/// <returns></returns>
		object Render(IActivitySpan span);
	}
}
