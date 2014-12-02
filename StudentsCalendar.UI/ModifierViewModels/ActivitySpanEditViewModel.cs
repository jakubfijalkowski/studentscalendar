using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ModifierViewModels
{
	/// <summary>
	/// Opisuje dostępny przedział aktywności.
	/// </summary>
	public sealed class AvailableSpanDescription
	{
		private readonly IActivitySpan _Span;
		private readonly string _Description;
		private readonly object _View;

		/// <summary>
		/// Pobiera przedział, który można edytować.
		/// </summary>
		public IActivitySpan Span
		{
			get { return this._Span; }
		}

		/// <summary>
		/// Pobiera opis przedziału.
		/// </summary>
		public string Description
		{
			get { return this._Description; }
		}

		/// <summary>
		/// Pobiera widok przypisany do danego przedziału.
		/// </summary>
		public object View
		{
			get { return this._View; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi
		/// </summary>
		/// <param name="span"></param>
		/// <param name="description"></param>
		/// <param name="view"></param>
		public AvailableSpanDescription(IActivitySpan span, string description, object view)
		{
			this._Span = span;
			this._Description = description;
			this._View = view;
		}
	}

	/// <summary>
	/// ViewModel który odpowiada za edycję przedziałów aktywności.
	/// </summary>
	public sealed class ActivitySpanEditViewModel
		: PropertyChangedBase, IViewModel
	{
		private readonly IReadOnlyList<AvailableSpanDescription> _AvailableSpans;
		private IActivitySpan _SelectedSpan;

		/// <summary>
		/// Pobiera listę dostępnych przedziałów aktywności.
		/// </summary>
		public IReadOnlyList<AvailableSpanDescription> AvailableSpans
		{
			get { return this._AvailableSpans; }
		}

		/// <summary>
		/// Wybrany przedział aktywności.
		/// </summary>
		public IActivitySpan SelectedSpan
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
		/// Tworzy ViewModel dla modyfikatora klas.
		/// </summary>
		/// <param name="dataProvider"></param>
		/// <param name="renderer"></param>
		/// <param name="modifier"></param>
		/// <returns></returns>
		public static ActivitySpanEditViewModel Create(IDataProvider dataProvider, IActivitySpanRenderer renderer, IClassesModifier modifier)
		{
			return Create<IDailyActivitySpan>(dataProvider, renderer, modifier.ActivitySpan, dataProvider.DailyActivitySpans);
		}

		/// <summary>
		/// Tworzy ViewModel dla modyfikatora dnia.
		/// </summary>
		/// <param name="dataProvider"></param>
		/// <param name="renderer"></param>
		/// <param name="modifier"></param>
		/// <returns></returns>
		public static ActivitySpanEditViewModel Create(IDataProvider dataProvider, IActivitySpanRenderer renderer, IDayModifier modifier)
		{
			return Create<IDailyActivitySpan>(dataProvider, renderer, modifier.ActivitySpan, dataProvider.DailyActivitySpans);
		}

		/// <summary>
		/// Tworzy ViewModel dla modyfikatora tygodnia.
		/// </summary>
		/// <param name="dataProvider"></param>
		/// <param name="renderer"></param>
		/// <param name="modifier"></param>
		/// <returns></returns>
		public static ActivitySpanEditViewModel Create(IDataProvider dataProvider, IActivitySpanRenderer renderer, IWeekModifier modifier)
		{
			return Create<IWeeklyActivitySpan>(dataProvider, renderer, modifier.ActivitySpan, dataProvider.WeeklyActivitySpans);
		}

		private ActivitySpanEditViewModel(IReadOnlyList<AvailableSpanDescription> descs, IActivitySpan selectedSpan)
		{
			this._AvailableSpans = descs;
			this._SelectedSpan = selectedSpan;
		}

		private static ActivitySpanEditViewModel Create<TType>(
			IDataProvider dataProvider, IActivitySpanRenderer renderer, IActivitySpan selectedSpan,
			IReadOnlyList<BaseDescription<TType>> availableSpans)
			where TType : IActivitySpan
		{
			var lst = from s in availableSpans
					  let isSelected = selectedSpan.GetType() == s.Type
					  let obj = isSelected ? selectedSpan : dataProvider.Create(s)
					  let desc = s.Name
					  let view = (object)null
					  select new AvailableSpanDescription(obj, desc, view);

			return new ActivitySpanEditViewModel(lst.ToList(), selectedSpan);
		}
	}
}
