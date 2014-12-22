using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.ActivitySpanViewModels;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// Obsługuje edycję przedziałów aktywności(przez dostarczanie odpowiednich ViewModeli).
	/// </summary>
	public interface IActivitySpanEditor
	{
		/// <summary>
		/// Tworzy odpowiedni ViewModel dla danego <see cref="IActivitySpan"/>.
		/// </summary>
		/// <param name="activitySpan"></param>
		/// <returns></returns>
		IActivitySpanViewModel CreateModel(IActivitySpan activitySpan);
	}
}
