using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
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

			ViewLocator.AddSubNamespaceMapping(".UI", ".Desktop");
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

		private void BuildContainer()
		{
			var builder = new ContainerBuilder();
			this.RegisterInfrastructure(builder);
			this.RegisterHandlers(builder);
			this.RegisterCore(builder);
			this.RegisterViewsAndViewModels(builder);
			this.Container = builder.Build();
		}

		private void RegisterInfrastructure(ContainerBuilder builder)
		{
			builder.RegisterType<EventAggregator>()
				.AsSelf().AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterType<MetroWindowManager>()
				.AsSelf().AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterType<ShellViewModel>()
				.AsSelf().AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterType<Platform.UserStorage>()
				.As<Core.Platform.IStorage>();
		}

		private void RegisterHandlers(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract && c.GetInterfaces().Any(i => i == typeof(IHandle)) && c.Name.EndsWith("Handler"))
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
					(c.IsInNamespaceOf<IActivitySpan>() || c.IsInNamespaceOf<IClassesModifier>() ||
					 c.IsInNamespaceOf<ICalendarGenerator>() || c.IsInNamespaceOf<IContentProvider>())
				)
				.AsImplementedInterfaces().AsSelf();

			builder.RegisterType<CalendarsManager>()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}

		private void RegisterViewsAndViewModels(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract && c.Name.EndsWith("View") && !c.IsInNamespaceOf<Controls.ClassesView>())
				.AsSelf();

			builder.RegisterAssemblyTypes(typeof(IShell).Assembly)
				.Where(c => !c.IsAbstract)
				.AsImplementedInterfaces().AsSelf();

			builder.RegisterAssemblyTypes(typeof(ShellViewModel).Assembly)
				.Where(c => !c.IsAbstract && c != typeof(ShellViewModel) && c.Name.EndsWith("ViewModel"))
				.AsImplementedInterfaces().AsSelf();
		}
	}
}
