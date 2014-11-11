using System.Windows;
using System.Windows.Controls;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.Desktop.Controls
{
	/// <summary>
	/// Interaction logic for ClassesView.xaml
	/// </summary>
	public partial class ClassesView : UserControl
	{
		private readonly double MinColumnWidth;

		private bool IsShort;
		private bool IsLong;
		private bool IsWide;

		public ClassesView()
		{
			InitializeComponent();

			this.MinColumnWidth = (double)this.FindResource("MinColumnWidth");

			this.DataContextChanged += this.OnDataContextChanged;
			this.SizeChanged += this.OnSizeChanged;
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var classes = (ArrangedClasses)e.NewValue;
			this.IsLong = classes.EndSlot - classes.StartSlot >= 1.5;
			this.IsShort = classes.EndSlot - classes.StartSlot <= 1.0;
			this.UpdateVisibility();
		}

		private void OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.IsWide = e.NewSize.Width >= this.MinColumnWidth * 2;
			this.UpdateVisibility();
		}

		private void UpdateVisibility()
		{
			if (this.IsWide)
			{
				this.MainColumn.MinWidth = this.MinColumnWidth * 2;
				this.MainColumn.Width = new GridLength(1, GridUnitType.Star);
				this.SecondColumn.Width = new GridLength(1, GridUnitType.Star);
			}
			else
			{
				this.MainColumn.MinWidth = 0;
				this.MainColumn.Width = new GridLength(1, GridUnitType.Star);
				this.SecondColumn.Width = new GridLength(0);
			}

			this.ShortHeader.Visibility = (!this.IsWide).ToVisibility();
			this.FullHeader.Visibility = this.IsWide.ToVisibility();
			this.FullNameDescription.Visibility = (this.IsLong && !this.IsWide).ToVisibility();
			this.Lecturer.Visibility = (!this.IsShort).ToVisibility();
			this.Notes.Visibility = this.IsLong.ToVisibility();
			this.SecondColumnNotes.Visibility = (!this.IsLong && this.IsWide).ToVisibility();
		}
	}
}
