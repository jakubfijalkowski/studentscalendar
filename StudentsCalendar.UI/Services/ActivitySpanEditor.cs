using System;
using Autofac.Features.Indexed;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.ActivitySpanViewModels;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// Implementuje <see cref="IActivitySpanEditor"/> i używa AutoFaca do tworzenia ViewModeli.
	/// </summary>
	public sealed class ActivitySpanEditor
		: IActivitySpanEditor
	{
		private readonly IIndex<Type, IActivitySpanViewModel> ViewModelFactory;

		public ActivitySpanEditor(IIndex<Type, IActivitySpanViewModel> viewModelFactory)
		{
			this.ViewModelFactory = viewModelFactory;
		}

		/// <inheritdoc />
		public IActivitySpanViewModel CreateModel(IActivitySpan activitySpan)
		{
			var type = typeof(BaseActivitySpanViewModel<>).MakeGenericType(activitySpan.GetType());
			return this.ViewModelFactory[type];
		}
	}
}
