using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Zmienia informacje o lokalizacji.
	/// </summary>
	public class ModifyLocationInfo
		: IClassesModifier
	{
		/// <summary>
		/// Pobiera lub zmienia nazę nowej lokalizacji.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Pobiera lub zmienia adres nowej lokalizacji.
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Pobiera lub zmienia nowy pokój.
		/// </summary>
		public string Room { get; set; }

		/// <inheritdoc />
		public IActivitySpan ActivitySpan { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt domyślnymi wartościami.
		/// </summary>
		public ModifyLocationInfo()
		{
			this.ActivitySpan = new EmptyActivitySpan();
		}

		/// <inheritdoc />
		public virtual IntermediateClasses Apply(IntermediateClasses data, GenerationContext context)
		{
			data.Location.Name = this.Name ?? data.Location.Name;
			data.Location.Address = this.Address ?? data.Location.Address;
			data.Location.Room = this.Room ?? data.Location.Room;
			return data;
		}
	}
}
