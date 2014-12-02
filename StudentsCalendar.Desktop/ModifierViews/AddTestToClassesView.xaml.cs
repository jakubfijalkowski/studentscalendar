using System.Windows.Controls;
using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.Desktop.ModifierViews
{
	/// <summary>
	/// Interaction logic for AddTestToClassesView.xaml
	/// </summary>
	public partial class AddTestToClassesView
		: UserControl
	{
		public AddTestToClassesView()
		{
			InitializeComponent();

			var vals = new EnumDesc[]
			{
				new EnumDesc { Name = "Niski", Value = TestPriority.Low },
				new EnumDesc { Name = "Średni", Value = TestPriority.Normal },
				new EnumDesc { Name = "Wysoki", Value = TestPriority.High }
			};
			this.PriorityCB.ItemsSource = vals;
		}

		private class EnumDesc
		{
			public string Name { get; set; }

			public TestPriority Value { get; set; }
		}
	}
}
