using Caliburn.Micro;
using StudentsCalendar.UI;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// ViewModel dla okien wewnątrz aplikacji.
	/// </summary>
	sealed class PopupsViewModel
		: Conductor<IPopupScreen>.Collection.OneActive
	{
		public override void DeactivateItem(IPopupScreen item, bool close)
		{
			base.DeactivateItem(item, true);
		}
	}
}
