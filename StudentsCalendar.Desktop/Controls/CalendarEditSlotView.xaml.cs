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
		public event EventHandler<ClassesEditEventArgs> EditClasses;

		/// <summary>
		/// Zdarzenie wywoływane, gdy użytkownik chce usunąć dane zajęcia.
		/// </summary>
		public event EventHandler<ClassesEditEventArgs> DeleteClasses;

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
				@event(this, new ClassesEditEventArgs(this.Slot, template));
			}
		}

		private void RaiseDeleteClasses(object sender, RoutedEventArgs e)
		{
			var template = (ClassesTemplate)((FrameworkElement)sender).DataContext;
			var @event = this.DeleteClasses;
			if (@event != null)
			{
				@event(this, new ClassesEditEventArgs(this.Slot, template));
			}
		}
	}
}
