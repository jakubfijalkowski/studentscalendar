using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// Odpowiada za wyświetlanie modyfikatorów w sposób strawny dla użytkownika.
	/// </summary>
	public interface IModifierRenderer
	{
		/// <summary>
		/// Opisuje wskazany modyfikator w sposób strawny dla użytkownika.
		/// </summary>
		/// <param name="modifier"></param>
		/// <param name="shouldBeUniversal"></param>
		/// <returns></returns>
		string Describe(IModifier modifier, bool shouldBeUniversal = false);
	}
}
