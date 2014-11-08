using Autofac;
using Caliburn.Metro.Autofac;
using StudentsCalendar.Core;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// Bootstrapper wiążący Caliburn.Micro, Autofaca i MahApps.Metro.
	/// </summary>
	sealed class Bootstrapper
		: CaliburnMetroAutofacBootstrapper<MainViewModel>
	{
		protected override void ConfigureContainer(Autofac.ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(CalendarEngine).Assembly)
				.Where(c => !c.IsAbstract &&
					(c.IsInNamespaceOf<IActivitySpan>() || c.IsInNamespaceOf<IClassesModifier>() || c == typeof(CalendarEngine)))
				.AsImplementedInterfaces().AsSelf();

			builder.RegisterAssemblyTypes(typeof(MainViewModel).Assembly)
				.Where(c => !c.IsAbstract && c.Name.EndsWith("ViewModel"));

			base.ConfigureContainer(builder);
		}
	}
}
