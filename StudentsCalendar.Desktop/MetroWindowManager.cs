using System.Windows;
using Caliburn.Micro;
using MahApps.Metro.Controls;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// Implementacja <see cref="IWindowManager"/> dla MahApps.
	/// </summary>
	sealed class MetroWindowManager
		: WindowManager
	{
		protected override Window EnsureWindow(object model, object view, bool isDialog)
		{
			MetroWindow window = view as MetroWindow;
			if (window == null)
			{
				window = new MainWindow { Content = view };
			}

			window.SetValue(View.IsGeneratedProperty, true);
			var inferredOwner = InferOwnerOf(window);
			if (inferredOwner != null)
			{
				window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				window.Owner = inferredOwner;
			}
			else
			{
				window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			}

			return window;
		}
	}
}
