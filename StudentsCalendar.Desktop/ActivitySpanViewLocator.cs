using System;
using StudentsCalendar.UI;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// <see cref="IActivitySpanViewLocator"/>, który wybiera widoki z przestrzeni nazw
	/// StudentsCalendar.Desktop.ActivitySpanViews.
	/// </summary>
	public sealed class ActivitySpanViewLocator
		: IActivitySpanViewLocator
	{
		private const string Format = "{0}.{1}View";
		private readonly string Namespace = typeof(ActivitySpanViews.EveryXMonthsActivitySpanView).Namespace;

		/// <inheritdoc />
		public Type LocateView(Core.ActivitySpans.IActivitySpan span)
		{
			var typeName = string.Format(Format, Namespace, span.GetType().Name);
			return Type.GetType(typeName);
		}
	}
}
