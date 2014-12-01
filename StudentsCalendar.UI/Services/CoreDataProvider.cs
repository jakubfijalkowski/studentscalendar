using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StudentsCalendar.Core;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// <see cref="IDataProvider"/>, który używa klas zdefiniowanych w projekcie StudentsCalendar.Core
	/// i <see cref="Activator"/>.
	/// </summary>
	/// <remarks>
	/// Zaangażowanie do tego AutoFaca wprowadza niepotrzebne skomplikowanie.
	/// </remarks>
	public sealed class CoreDataProvider
		: IDataProvider
	{
		/// <inheritdoc />
		public IReadOnlyList<ClassesModifierDescription> ClassesModifiers { get; private set; }

		/// <inheritdoc />
		public IReadOnlyList<DayModifierDescription> DayModifiers { get; private set; }

		/// <inheritdoc />
		public IReadOnlyList<WeekModifierDescription> WeekModifiers { get; private set; }

		/// <inheritdoc />
		public IReadOnlyList<CalendarModifierDescription> CalendarModifiers { get; private set; }

		/// <inheritdoc />
		public IReadOnlyList<DailyActivitySpanDescription> DailyActivitySpans { get; private set; }

		/// <inheritdoc />
		public IReadOnlyList<WeeklyActivitySpanDescription> WeeklyActivitySpans { get; private set; }

		/// <summary>
		/// Buduje wszystkie dostępne obiekty.
		/// </summary>
		public CoreDataProvider(IModifierRenderer modifierRenderer, IActivitySpanRenderer activitySpanRenderer)
		{
			var assembly = typeof(CurrentCalendar).GetTypeInfo().Assembly;

			this.ClassesModifiers = GetTypes<IClassesModifier, ClassesModifierDescription>(assembly, modifierRenderer.Describe);
			this.DayModifiers = GetTypes<IDayModifier, DayModifierDescription>(assembly, modifierRenderer.Describe);
			this.WeekModifiers = GetTypes<IWeekModifier, WeekModifierDescription>(assembly, modifierRenderer.Describe);
			this.CalendarModifiers = GetTypes<ICalendarModifier, CalendarModifierDescription>(assembly, modifierRenderer.Describe);
			this.DailyActivitySpans = GetTypes<IDailyActivitySpan, DailyActivitySpanDescription>(assembly, activitySpanRenderer.Describe);
			this.WeeklyActivitySpans = GetTypes<IWeeklyActivitySpan, WeeklyActivitySpanDescription>(assembly, activitySpanRenderer.Describe);
		}

		/// <inheritdoc />
		public TResult Create<TResult>(BaseDescription<TResult> description)
		{
			return CreateInstance<TResult>(description.Type.GetTypeInfo());
		}

		private static IReadOnlyList<TDescription> GetTypes<TConstraint, TDescription>(Assembly assembly, Func<TConstraint, bool, string> describe)
			where TDescription : BaseDescription<TConstraint>
		{
			var types = from ti in assembly.DefinedTypes
						where !ti.IsInterface && !ti.IsAbstract
						where typeof(TConstraint).GetTypeInfo().IsAssignableFrom(ti)
						let sample = CreateInstance<TConstraint>(ti)
						let name = describe(sample, true)
						select CreateDescription<TDescription>(name, ti);
			return types.ToList();
		}

		private static TType CreateInstance<TType>(TypeInfo ti)
		{
			return (TType)Activator.CreateInstance(ti.AsType());
		}

		private static TDescription CreateDescription<TDescription>(string name, TypeInfo type)
		{
			return (TDescription)Activator.CreateInstance(typeof(TDescription), new object[] { name, type.AsType() });
		}
	}
}
