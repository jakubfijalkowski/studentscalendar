using System;
using System.Windows;
using System.Windows.Controls;
using StudentsCalendar.Core.Templates;
using StudentsCalendar.UI.Popups;

namespace StudentsCalendar.Desktop.Controls
{
	/// <summary>
	/// Interaction logic for CalendarEditSlotView.xaml
	/// </summary>
	public partial class CalendarEditSlotView
		: UserControl
	{
		/// <summary>
		/// Zdarzenie wywoływane, gdy użytkownik chce dodać nowe zajęcia do klasy.
		/// </summary>
		public event EventHandler<AddClassesEventArgs> AddClasses;

		/// <summary>
		/// Zdarzenie wywoływane, gdy użytkownik chce edytować dany szablon zajęć.
		/// </summary>
		public event EventHandler<ClassesEventArgs> EditClasses;

		/// <summary>
		/// Zdarzenie wywoływane, gdy użytkownik chce usunąć dane zajęcia.
		/// </summary>
		public event EventHandler<ClassesEventArgs> DeleteClasses;

		private CalendarEditSlot Slot
		{
			get { return (CalendarEditSlot)this.DataContext; }
		}

		public CalendarEditSlotView()
		{
			InitializeComponent();
		}

		private void RaiseAddClasses(object sender, RoutedEventArgs e)
		{
			var @event = this.AddClasses;
			if (@event != null)
			{
				@event(this, new AddClassesEventArgs(this.Slot));
			}
		}

		private void RaiseEditClasses(object sender, RoutedEventArgs e)
		{
			var template = (ClassesTemplate)((FrameworkElement)sender).DataContext;
			var @event = this.EditClasses;
			if (@event != null)
			{
				@event(this, new ClassesEventArgs(this.Slot, template));
			}
		}

		private void RaiseDeleteClasses(object sender, RoutedEventArgs e)
		{
			var template = (ClassesTemplate)((FrameworkElement)sender).DataContext;
			var @event = this.DeleteClasses;
			if (@event != null)
			{
				@event(this, new ClassesEventArgs(this.Slot, template));
			}
		}
	}

	/// <summary>
	/// Dane zdarzenia <see cref="CalendarEditSlotView.AddClasses"/>.
	/// </summary>
	public sealed class AddClassesEventArgs
		: EventArgs
	{
		private readonly CalendarEditSlot _EditSlot;

		/// <summary>
		/// Pobiera slot, który został użyty.
		/// </summary>
		public CalendarEditSlot EditSlot
		{
			get { return this._EditSlot; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		/// <param name="slot"></param>
		public AddClassesEventArgs(CalendarEditSlot slot)
		{
			this._EditSlot = slot;
		}
	}

	/// <summary>
	/// Dane zdarzenia <see cref="CalendarEditSlotView.EditClasses"/> i <see cref="CalendarEditSlotView.DeleteClasses"/>.
	/// </summary>
	public sealed class ClassesEventArgs
		: EventArgs
	{
		private readonly CalendarEditSlot _EditSlot;
		private readonly ClassesTemplate _Template;

		/// <summary>
		/// Pobiera slot, który został użyty.
		/// </summary>
		public CalendarEditSlot EditSlot
		{
			get { return this._EditSlot; }
		}

		/// <summary>
		/// Pobiera kliknięty szablon.
		/// </summary>
		public ClassesTemplate Template
		{
			get { return this._Template; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		/// <param name="slot"></param>
		/// <param name="template"></param>
		public ClassesEventArgs(CalendarEditSlot slot, ClassesTemplate template)
		{
			this._EditSlot = slot;
			this._Template = template;
		}
	}
}
