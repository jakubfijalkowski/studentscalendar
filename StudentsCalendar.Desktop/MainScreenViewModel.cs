using Caliburn.Micro;
using StudentsCalendar.UI;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// ViewModel zarządzający historią wyświetleń głównego okna.
	/// </summary>
	sealed class MainScreenViewModel
		: Conductor<IMainScreen>.Collection.OneActive
	{
		public override void DeactivateItem(IMainScreen item, bool close)
		{
			base.DeactivateItem(item, true);
		}
	}
}
