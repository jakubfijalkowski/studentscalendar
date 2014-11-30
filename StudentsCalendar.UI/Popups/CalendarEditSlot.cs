using System.Collections.ObjectModel;
using Caliburn.Micro;
using NodaTime;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// Opisuje pojedynczy slot na ekranie edycji kalendarza.
	/// </summary>
	public sealed class CalendarEditSlot
		: PropertyChangedBase
	{
		private readonly IsoDayOfWeek _DayOfWeek;
		private readonly LocalTime _TimeSlot;

		private readonly ObservableCollection<ClassesTemplate> _Templates = new ObservableCollection<ClassesTemplate>();
		private bool _IsEmpty;

		/// <summary>
		/// Pobiera dzień tygodnia, w którym znajduje się slot.
		/// </summary>
		public IsoDayOfWeek DayOfWeek
		{
			get { return this._DayOfWeek; }
		}

		/// <summary>
		/// Pobiera godzinnę, w której znajduje się dany slot.
		/// </summary>
		public LocalTime TimeSlot
		{
			get { return this._TimeSlot; }
		}


		/// <summary>
		/// Pobiera listę szablonów przypisaną do tego slotu.
		/// </summary>
		public ObservableCollection<ClassesTemplate> Templates
		{
			get { return this._Templates; }
		}

		/// <summary>
		/// Pobiera wartość wskazującą, czy slot jest pusty, czy nie.
		/// </summary>
		public bool IsEmpty
		{
			get { return this._IsEmpty; }
			set
			{
				if (this._IsEmpty != value)
				{
					this._IsEmpty = value;
					this.NotifyOfPropertyChange();
				}
			}
		}

		/// <summary>
		/// Inicjalizuje obiekt.
		/// </summary>
		/// <param name="dayOfWeek"></param>
		/// <param name="timeSlot"></param>
		public CalendarEditSlot(IsoDayOfWeek dayOfWeek, LocalTime timeSlot)
		{
			this._DayOfWeek = dayOfWeek;
			this._TimeSlot = timeSlot;

			this.IsEmpty = true;
			this.Templates.CollectionChanged += this.OnTemplatesChanged;
		}

		private void OnTemplatesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			this.IsEmpty = this.Templates.Count == 0;
		}
	}
}
