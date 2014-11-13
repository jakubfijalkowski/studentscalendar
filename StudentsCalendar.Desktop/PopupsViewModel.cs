using Caliburn.Micro;
using StudentsCalendar.UI;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// ViewModel dla okien wewnątrz aplikacji.
	/// </summary>
	sealed class PopupsViewModel
		: Conductor<IViewModel>.Collection.OneActive
	{
		public override void DeactivateItem(IViewModel item, bool close)
		{
			base.DeactivateItem(item, true);
		}
	}
}
