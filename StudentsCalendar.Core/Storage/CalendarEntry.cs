using System.ComponentModel;
using System.Runtime.CompilerServices;
using NodaTime;

namespace StudentsCalendar.Core.Storage
{
	/// <summary>
	/// Opisuje wpis w bazie kalendarzy, który służy do identyfikacji właściwych szablonów.
	/// Pozwala opóźnić wczytanie szablonu głównego, i pominąć wczytywanie pozostałych szablonów.
	/// </summary>
	/// TODO: consider introducint wrapper around it that implements INotifyPropertyChanged and
	/// let the object be POCO
	public sealed class CalendarEntry
		: INotifyPropertyChanged
	{
		private readonly string _Id;
		private string _Name;
		private LocalDate _StartDate;
		private LocalDate _EndDate;
		private bool _IsActive;

		/// <summary>
		/// Pobiera identyfikator wpisu.
		/// </summary>
		public string Id
		{
			get { return this._Id; }
		}

		/// <summary>
		/// Pobiera lub zmienia nazwę kalendarza.
		/// </summary>
		public string Name
		{
			get { return this._Name; }
			set
			{
				if (this._Name != value)
				{
					this._Name = value;
					this.OnPropertyChanged();
				}
			}
		}


		/// <summary>
		/// Pobiera lub zmienia datę początku aktywności kalendarza.
		/// </summary>
		public LocalDate StartDate
		{
			get { return this._StartDate; }
			set
			{
				if (this._StartDate != value)
				{
					this._StartDate = value;
					this.OnPropertyChanged();
				}
			}
		}


		/// <summary>
		/// Pobiera lub zmienia datę końca aktywności kalendarza.
		/// </summary>
		public LocalDate EndDate
		{
			get { return this._EndDate; }
			set
			{
				if (this._EndDate != value)
				{
					this._EndDate = value;
					this.OnPropertyChanged();
				}
			}
		}


		/// <summary>
		/// Wskazuje, czy kalendarz jest aktywny, czy nie.
		/// </summary>
		/// <remarks>
		/// W ramach aplikacji może istnieć tylko jeden aktywny wpis.
		/// </remarks>
		public bool IsActive
		{
			get { return this._IsActive; }
			set
			{
				if (this._IsActive != value)
				{
					this._IsActive = value;
					this.OnPropertyChanged();
				}
			}
		}


		public CalendarEntry(string id)
		{
			this._Id = id;
		}

		/// <inheritdoc />
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var @event = this.PropertyChanged;
			if (@event != null)
			{
				@event(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
