using System;
using System.Windows;
using System.Windows.Controls;
using StudentsCalendar.UI.Popups;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.Desktop.Controls
{
	/// <summary>
	/// Interaction logic for ModifierList.xaml
	/// </summary>
	public partial class ModifierList
		: UserControl
	{
		/// <summary>
		/// Użytkownik chce edytować wskazany modyfikator.
		/// </summary>
		public event EventHandler<ModifierDescription> EditModifier;

		/// <summary>
		/// Użytkownik chce usunąć dany modyfikator.
		/// </summary>
		public event EventHandler<ModifierDescription> DeleteModifier;

		/// <summary>
		/// Użytkownik chce dodać modyfikator.
		/// </summary>
		/// <remarks>
		/// Dane zdarzenia to tak naprawdę <see cref="BaseDescription{TModifier}"/>, ale ze względu
		/// na ograniczenia dla typów generycznych, przekazywany jest <c>object</c>.
		/// </remarks>
		public event EventHandler<AddModifierEventArgs> AddModifier;

		public ModifierList()
		{
			InitializeComponent();
		}

		private void OpenContextMenu(object sender, RoutedEventArgs e)
		{
			var cm = ((Button)sender).ContextMenu;
			cm.PlacementTarget = (Button)sender;
			cm.IsOpen = !cm.IsOpen;
		}

		private void EditModifierClick(object sender, RoutedEventArgs e)
		{
			var data = ((Button)sender).DataContext as ModifierDescription;
			var @event = this.EditModifier;
			if (@event != null)
			{
				@event(this, data);
			}
		}

		private void DeleteModifierClick(object sender, RoutedEventArgs e)
		{
			var data = ((Button)sender).DataContext as ModifierDescription;
			var @event = this.DeleteModifier;
			if (@event != null)
			{
				@event(this, data);
			}
		}

		private void AddModifierClick(object sender, RoutedEventArgs e)
		{
			var data = ((MenuItem)sender).DataContext;
			var @event = this.AddModifier;
			if (@event != null)
			{
				@event(this, new AddModifierEventArgs(data));
			}
		}
	}
}