using System.Windows;
using System.Windows.Controls;

namespace StudentsCalendar.Desktop.Controls
{
	/// <summary>
	/// <see cref="Canvas"/> bugfix - <see cref="FrameworkElement.ActualWidth"/> and <see cref="FrameworkElement.ActualHeight"/> are synced with
	/// <see cref="CorrectActualWidth"/> and <see cref="CorrectActualHeight"/> but PropertyChanged event is raised.
	/// </summary>
	public sealed class CustomCanvas
		: Canvas
	{
		private static readonly DependencyProperty _CorrectActualWidthProperty =
			DependencyProperty.Register("CorrectActualWidth", typeof(double), typeof(CustomCanvas), new PropertyMetadata(0.0));
		private static readonly DependencyProperty _CorrectActualHeightProperty =
			DependencyProperty.Register("CorrectActualHeight", typeof(double), typeof(CustomCanvas), new PropertyMetadata(0.0));

		/// <summary>
		/// Identifies the <see cref="CorrectActualWidth"/> property.
		/// </summary>
		public static DependencyProperty CorrectActualWidthProperty
		{
			get { return _CorrectActualWidthProperty; }
		}

		/// <summary>
		/// Identifies the <see cref="CorrectActualHeight"/> property.
		/// </summary>
		public static DependencyProperty CorrectActualHeightProperty
		{
			get { return _CorrectActualHeightProperty; }
		}

		/// <summary>
		/// Actual width.
		/// </summary>
		public double CorrectActualWidth
		{
			get { return (double)GetValue(CorrectActualWidthProperty); }
			private set { SetValue(CorrectActualWidthProperty, value); }
		}

		/// <summary>
		/// Actual height.
		/// </summary>
		public double CorrectActualHeight
		{
			get { return (double)GetValue(CorrectActualHeightProperty); }
			set { SetValue(CorrectActualHeightProperty, value); }
		}

		/// <summary>
		/// Initializes canvas.
		/// </summary>
		public CustomCanvas()
		{
			this.SizeChanged += Canvas_SizeChanged;
		}

		private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.CorrectActualWidth = e.NewSize.Width;
			this.CorrectActualHeight = e.NewSize.Height;
		}
	}
}

