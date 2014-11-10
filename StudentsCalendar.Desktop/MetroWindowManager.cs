using System;
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
		private readonly Func<MainWindow> WindowCreator;

		public MetroWindowManager(Func<MainWindow> windowCreator)
		{
			this.WindowCreator = windowCreator;
		}

		protected override Window EnsureWindow(object model, object view, bool isDialog)
		{
			MetroWindow window = view as MetroWindow;
			if (window == null)
			{
				window = this.WindowCreator();
				window.Content = view;
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
