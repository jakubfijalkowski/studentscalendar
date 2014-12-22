using Caliburn.Micro;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	/// <summary>
	/// Bazowa klasa dla ViewModeli do edycji <see cref="IActivitySpan"/>.
	/// </summary>
	public abstract class BaseActivitySpanViewModel<TActivitySpan>
		: PropertyChangedBase, IViewModel, IActivitySpanViewModel
		where TActivitySpan : class, IActivitySpan
	{
		private IActivitySpanRenderer Renderer;
		private TActivitySpan _Span;

		/// <summary>
		/// Pobiera edytowany przedział aktywności.
		/// </summary>
		public TActivitySpan Span
		{
			get { return this._Span; }
			private set
			{
				if (this._Span != value)
				{
					this._Span = value;
					this.OnSpanChanged();
				}
			}
		}

		/// <inheritdoc />
		IActivitySpan IActivitySpanViewModel.Span
		{
			get
			{
				return this.Span;
			}
			set
			{
				this.Span = value as TActivitySpan;
			}
		}

		/// <inheritdoc />
		public string Name { get; private set; }

		protected BaseActivitySpanViewModel(IActivitySpanRenderer renderer)
		{
			this.Renderer = renderer;
		}

		protected virtual void OnSpanChanged()
		{
			this.Name = this.Renderer.Describe(this.Span, true);

			this.NotifyOfPropertyChange(() => this.Span);
			this.NotifyOfPropertyChange(() => this.Name);
		}
	}
}
