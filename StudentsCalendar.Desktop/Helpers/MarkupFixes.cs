using System.Globalization;
using System.Windows.Data;

namespace StudentsCalendar.Desktop.Helpers
{
	/// <summary>
	/// Fix na <see cref="MultiBinding"/> który używa <see cref="CultureInfo.CurrentCulture"/> jako domyślnej.
	/// </summary>
	class MultiBindingWithCurrentCulture
		: MultiBinding
	{
		public MultiBindingWithCurrentCulture()
		{
			this.ConverterCulture = CultureInfo.CurrentCulture;
		}
	}

	/// <summary>
	/// Fix na <see cref="Binding"/> który używa <see cref="CultureInfo.CurrentCulture"/> jako domyślnej.
	/// </summary>
	class BindingWithCurrentCulture
		: Binding
	{
		public BindingWithCurrentCulture()
		{
			this.ConverterCulture = CultureInfo.CurrentCulture;
		}

		public BindingWithCurrentCulture(string path)
			: base(path)
		{
			this.ConverterCulture = CultureInfo.CurrentCulture;
		}
	}
}
