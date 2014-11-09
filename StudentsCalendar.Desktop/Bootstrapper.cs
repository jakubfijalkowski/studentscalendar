using Autofac;
using Caliburn.Metro.Autofac;
using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.UI;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// Bootstrapper wiążący Caliburn.Micro, Autofaca i MahApps.Metro.
	/// </summary>
	sealed class Bootstrapper
		: CaliburnMetroAutofacBootstrapper<IShell>
	{
		protected override void Configure()
		{
			base.Configure();

			ViewLocator.AddSubNamespaceMapping(".UI", ".Desktop");
		}

		protected override void ConfigureContainer(Autofac.ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(CalendarEngine).Assembly)
				.Where(c => !c.IsAbstract &&
					(c.IsInNamespaceOf<IActivitySpan>() || c.IsInNamespaceOf<IClassesModifier>() ||
					 c.IsInNamespaceOf<ICalendarGenerator>() || c.IsInNamespaceOf<Calendar>() ||
					 c == typeof(CalendarEngine)))
				.AsImplementedInterfaces().AsSelf();

			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract)
				.AsImplementedInterfaces().AsSelf();

			builder.RegisterAssemblyTypes(typeof(ShellViewModel).Assembly)
				.Where(c => !c.IsAbstract && (c.Name.EndsWith("ViewModel") || c.IsInNamespaceOf<Platform.SampleStorage>()))
				.AsImplementedInterfaces().AsSelf();

			base.ConfigureContainer(builder);
		}
	}
}
