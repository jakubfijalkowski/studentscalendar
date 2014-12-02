using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.UI.ModifierViewModels
{
	public sealed class AddTestToClassesViewModel
		: BaseModifierViewModel<AddTestToClasses>
	{ }

	public sealed class CancelClassesViewModel
		: BaseModifierViewModel<CancelClasses>
	{ }

	public sealed class CancelClassesInRangeViewModel
		: BaseModifierViewModel<CancelClassesInRange>
	{ }

	public sealed class CancelDayViewModel
		: BaseModifierViewModel<CancelDay>
	{ }

	public sealed class CancelWeekViewModel
		: BaseModifierViewModel<CancelWeek>
	{ }

	public sealed class ChangeWeekdayViewModel
		: BaseModifierViewModel<ChangeWeekday>
	{ }
}
