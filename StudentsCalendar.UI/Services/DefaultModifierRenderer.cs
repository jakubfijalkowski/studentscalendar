using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
		public string Describe(IModifier modifier)
		{
			return (string)this.Descriptions[modifier.GetType()]
				.Invoke(null, new object[] { modifier });
		}

		private static string Describe(AddTestToClasses mod)
		{
			return string.Format("Dodaj test '{0}'", mod.Title);
		}

		private static string Describe(CancelClasses mod)
		{
			return "Odwołaj zajęcia";
		}

		private static string Describe(CancelClassesInRange mod)
		{
			return string.Format(CultureInfo.CurrentCulture, "Odwołaj zajęcia od {0} do {1}", mod.StartDate, mod.EndDate);
		}

		private static string Describe(CancelDay mod)
		{
			return "Wolny dzień";
		}

		private static string Describe(CancelWeek mod)
		{
			return "Wolny tydzień";
		}

		private static string Describe(ChangeWeekday mod)
		{
			return string.Format(CultureInfo.CurrentCulture, "Zmień plan na {0:dddd}", mod.DayOfWeek);
		}

		private static string Describe(ModifyClassesInfo mod)
		{
			return "Zmień informacje o zajęciach";
		}

		private static string Describe(ModifyLecturerInfo mod)
		{
			return "Zmień dane prowadzącego";
		}

		private static string Describe(ModifyLocationInfo mod)
		{
			return "Zmień dane o lokalizacji";
		}
	}
}
