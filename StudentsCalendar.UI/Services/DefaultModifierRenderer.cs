using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using NodaTime;
using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// Wyświetla wbudowane modyfikatory.
	/// </summary>
	public sealed class DefaultModifierRenderer
		: IModifierRenderer
	{
		private readonly Dictionary<Type, MethodInfo> Descriptions;

		public DefaultModifierRenderer()
		{
			this.Descriptions = typeof(DefaultModifierRenderer)
				.GetRuntimeMethods()
				.Where(m => m.Name == "Describe")
				.ToDictionary(m => m.GetParameters()[0].ParameterType);
		}

		/// <inheritdoc />
		public string Describe(IModifier modifier, bool shouldBeUniversal = false)
		{
			return (string)this.Descriptions[modifier.GetType()]
				.Invoke(null, new object[] { modifier, shouldBeUniversal });
		}

		private static string Describe(AddTestToClasses mod, bool shouldBeUniversal)
		{
			var str = "Dodaj test";
			if (!shouldBeUniversal)
			{
				str += " '" + mod.Title + "'";
			}
			return str;
		}

		private static string Describe(CancelClasses mod, bool shouldBeUniversal)
		{
			return "Odwołaj zajęcia";
		}

		private static string Describe(CancelClassesInRange mod, bool shouldBeUniversal)
		{
			if (shouldBeUniversal)
			{
				return "Odwołaj zajęcia od ... do ...";
			}
			return string.Format(CultureInfo.CurrentCulture, "Odwołaj zajęcia od {0} do {1}", mod.StartDate, mod.EndDate);
		}

		private static string Describe(CancelDay mod, bool shouldBeUniversal)
		{
			return "Wolny dzień";
		}

		private static string Describe(CancelWeek mod, bool shouldBeUniversal)
		{
			return "Wolny tydzień";
		}

		private static string Describe(ChangeWeekday mod, bool shouldBeUniversal)
		{
			if (shouldBeUniversal)
			{
				return "Zmień plan na inny dzień";
			}
			return string.Format(CultureInfo.CurrentCulture, "Zmień plan na {0:dddd}", new LocalDate().Next(mod.DayOfWeek));
		}

		private static string Describe(ModifyClassesInfo mod, bool shouldBeUniversal)
		{
			return "Zmień informacje o zajęciach";
		}

		private static string Describe(ModifyLecturerInfo mod, bool shouldBeUniversal)
		{
			return "Zmień dane prowadzącego";
		}

		private static string Describe(ModifyLocationInfo mod, bool shouldBeUniversal)
		{
			return "Zmień dane o lokalizacji";
		}
	}
}
