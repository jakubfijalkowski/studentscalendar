using Caliburn.Micro;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// ViewModel dla okien wewnątrz aplikacji.
	/// </summary>
	sealed class WindowsViewModel
		: Conductor<object>.Collection.OneActive
	{
		public override void DeactivateItem(object item, bool close)
		{
			base.DeactivateItem(item, true);
		}
	}
}
