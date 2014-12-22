using System;
using System.Collections.Generic;
using Autofac;
using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.UI;
using StudentsCalendar.UI.ActivitySpanViewModels;
using StudentsCalendar.UI.Dialogs;
using StudentsCalendar.UI.ModifierViewModels;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// Bootstrapper wiążący Caliburn.Micro, Autofaca i MahApps.Metro.
	/// </summary>
	sealed class Bootstrapper
		: BootstrapperBase
	{
		private IContainer Container;

		public Bootstrapper()
		{
			this.Initialize();
		}

		/// <inheritdoc />
		protected override void Configure()
		{
			this.BuildContainer();
			this.ConfigureConventions();
		}

		/// <inheritdoc />
		protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
		{
			this.DisplayRootViewFor<IShell>();
			this.Container.Resolve<IEventAggregator>().PublishOnCurrentThread(new UI.Events.ApplicationStartedEvent());
		}

		/// <inheritdoc />
		protected override object GetInstance(Type service, string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				return this.Container.Resolve(service);
			}
			else
			{
				return this.Container.ResolveNamed(key, service);
			}
		}

		/// <inheritdoc />
		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return this.Container.Resolve(typeof(IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
		}

		/// <inheritdoc />
		protected override void BuildUp(object instance)
		{
			this.Container.InjectProperties(instance);
		}
		private void ConfigureConventions()
		{
			ViewLocator.AddSubNamespaceMapping(".UI.ModifierViewModels", ".Desktop.ModifierViews");
			ViewLocator.AddSubNamespaceMapping(".UI", ".Desktop");
		}

		private void BuildContainer()
		{
			var builder = new ContainerBuilder();
			this.RegisterCore(builder);
			this.RegisterInfrastructure(builder);
			this.RegisterHandlers(builder);
			this.RegisterViewsAndViewModels(builder);
			this.Container = builder.Build();
		}

		private void RegisterInfrastructure(ContainerBuilder builder)
		{
			builder.RegisterType<EventAggregator>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterType<MetroWindowManager>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterType<MainScreenViewModel>()
				.AsSelf();

			builder.RegisterType<PopupsViewModel>()
				.AsSelf();

			builder.RegisterType<ShellViewModel>()
				.AsSelf().AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterType<Platform.UserStorage>()
				.As<Core.Platform.IStorage>();

			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract && c.IsInNamespaceOf<UI.Services.ILayoutArranger>())
				.AsImplementedInterfaces().AsSelf();
		}

		private void RegisterHandlers(ContainerBuilder builder)
		{
			//TODO: is this really needed?
			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract && c.Implements<IHandle>() && c.Name.EndsWith("Handler"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope()
				.OnActivated(a =>
				{
					var handler = a.Instance as IHandle;
					a.Context.Resolve<IEventAggregator>().Subscribe(handler);
				})
				.AutoActivate();
		}

		public void RegisterCore(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(GenerationEngine).Assembly)
				.Where(c => !c.IsAbstract &&
					(c.IsInNamespaceOf<IDailyActivitySpan>() || c.IsInNamespaceOf<IClassesModifier>() ||
					 c.IsInNamespaceOf<ICalendarGenerator>() || c.IsInNamespaceOf<IContentProvider>())
				)
				.AsImplementedInterfaces().AsSelf();

			builder.RegisterType<CalendarsManager>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterType<CurrentCalendar>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}

		private void RegisterViewsAndViewModels(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(Bootstrapper).Assembly)
				.Where(c =>
					!c.IsAbstract && c.IsInNamespaceOf<Dialogs.ErrorDialogView>() &&
					c.Implements<IDialogView>() && c.Inherits<MahApps.Metro.Controls.Dialogs.BaseMetroDialog>() &&
					c.HasAttribute<DialogAttribute>())
				.AsSelf()
				.Keyed<IDialogView>(t => DialogAttribute.GetDialogType(t));

			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract && c.Name.EndsWith("View") && !c.IsInNamespaceOf<Controls.ClassesView>())
				.AsSelf();

			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract && c.Name.EndsWith("ViewModel") && !c.IsInNamespaceOf<BaseModifierViewModel<IModifier>>())
				.Keyed<IViewModel>(t => t)
				.AsSelf();

			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract && c.IsInNamespaceOf<BaseModifierViewModel<IModifier>>())
				.Keyed<IViewModel>(t => t.BaseType)
				.AsSelf();

			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract && c.IsInNamespaceOf<BaseActivitySpanViewModel<IActivitySpan>>())
				.Keyed<IViewModel>(t => t.BaseType)
				.AsSelf();
		}
	}
}
