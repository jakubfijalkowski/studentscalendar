using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI.ActivitySpanViewModels;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ModifierViewModels
{
	/// <summary>
	/// ViewModel który odpowiada za edycję przedziałów aktywności.
	/// </summary>
	public sealed class ActivitySpanEditViewModel
		: PropertyChangedBase, IViewModel
	{
		private readonly IReadOnlyList<IActivitySpanViewModel> _AvailableSpans;
		private IActivitySpanViewModel _SelectedSpan;

		/// <summary>
		/// Pobiera listę dostępnych przedziałów aktywności.
		/// </summary>
		public IReadOnlyList<IActivitySpanViewModel> AvailableSpans
		{
			get { return this._AvailableSpans; }
		}

		/// <summary>
		/// Wybrany przedział aktywności.
		/// </summary>
		public IActivitySpanViewModel SelectedSpan
		{
			get { return this._SelectedSpan; }
			set
			{
				if (this._SelectedSpan != value)
				{
					this._SelectedSpan = value;
					this.NotifyOfPropertyChange();
				}
			}
		}

		/// <summary>
		/// Wywoływane, gdy modyfikator jest zapisywany.
		/// </summary>
		public void Save()
		{
			this.SelectedSpan.Save();
		}

		/// <summary>
		/// Tworzy ViewModel dla modyfikatora klas.
		/// </summary>
		/// <param name="dataProvider"></param>
		/// <param name="editor"></param>
		/// <param name="modifier"></param>
		/// <returns></returns>
		public static ActivitySpanEditViewModel Create(IDataProvider dataProvider, IActivitySpanEditor editor, IClassesModifier modifier)
		{
			return Create<IDailyActivitySpan>(dataProvider, editor, modifier.ActivitySpan, dataProvider.DailyActivitySpans);
		}

		/// <summary>
		/// Tworzy ViewModel dla modyfikatora dnia.
		/// </summary>
		/// <param name="dataProvider"></param>
		/// <param name="editor"></param>
		/// <param name="modifier"></param>
		/// <returns></returns>
		public static ActivitySpanEditViewModel Create(IDataProvider dataProvider, IActivitySpanEditor editor, IDayModifier modifier)
		{
			return Create<IDailyActivitySpan>(dataProvider, editor, modifier.ActivitySpan, dataProvider.DailyActivitySpans);
		}

		/// <summary>
		/// Tworzy ViewModel dla modyfikatora tygodnia.
		/// </summary>
		/// <param name="dataProvider"></param>
		/// <param name="editor"></param>
		/// <param name="modifier"></param>
		/// <returns></returns>
		public static ActivitySpanEditViewModel Create(IDataProvider dataProvider, IActivitySpanEditor editor, IWeekModifier modifier)
		{
			return Create<IWeeklyActivitySpan>(dataProvider, editor, modifier.ActivitySpan, dataProvider.WeeklyActivitySpans);
		}

		private ActivitySpanEditViewModel(IReadOnlyList<IActivitySpanViewModel> descs, IActivitySpan selectedSpan)
		{
			this._AvailableSpans = descs;
			this._SelectedSpan = descs.First(d => d.Span == selectedSpan);
		}

		private static ActivitySpanEditViewModel Create<TType>(
			IDataProvider dataProvider, IActivitySpanEditor editor, IActivitySpan selectedSpan,
			IReadOnlyList<BaseDescription<TType>> availableSpans)
			where TType : IActivitySpan
		{
			var lst = from s in availableSpans
					  let isSelected = selectedSpan.GetType() == s.Type
					  let obj = isSelected ? selectedSpan : dataProvider.Create(s)
					  select editor.CreateModel(obj);

			return new ActivitySpanEditViewModel(lst.ToList(), selectedSpan);
		}
	}
}
