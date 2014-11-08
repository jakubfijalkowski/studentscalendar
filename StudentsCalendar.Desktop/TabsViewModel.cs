using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using StudentsCalendar.UI;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// ViewModel dla głównych kart aplikacji.
	/// </summary>
	sealed class TabsViewModel
		: Conductor<IMainTab>.Collection.OneActive
	{
		/// <summary>
		/// Inicjalizuje model wszystkimi dostępnymi kartami.
		/// </summary>
		/// <param name="tabs"></param>
		public TabsViewModel(IEnumerable<IMainTab> tabs)
		{
			this.Items.AddRange(tabs.OrderBy(t => t.Priority));
		}
	}
}
