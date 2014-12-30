using System.Collections.Generic;
using System.Linq;
using NodaTime;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Dodaje przerwy między zajęciami.
	/// </summary>
	/// <remarks>
	/// Sposób działania jest dostosowany do zajęć prowadzonych na wydziale MiNI Politechniki Warszawskiej
	/// (na innych wydziałach mogą być nieznaczne odstępstwa, ale ogólnie też powinno się sprawdzać).
	/// 
	/// W opisie zakładamy, że <see cref="BreakDuration"/> = 15, <see cref="ClassesDuration"/> = 45 i
	/// <see cref="AddAtBeginning"/> = <c>true</c>.
	/// 
	/// Zajęcia reprezentowane są jako pełne godziny, które mogą być połączone w bloki(np. 2 zajęcia ciągiem).
	/// Zajęcia przeważnie zaczynają się 15 minut po pełnej godzinie, ale to 15 minut jest traktowane przez
	/// ten modyfikator jako przerwa którą musi dodać.
	/// I tak np. dla zajęć, które w rzeczywistości trwają od godz. 9:15 do 10:00, i są w aplikacji reprezentowane
	/// jako zajęcia od 9:00 do 10:00, modyfikator obetnie 15 minut na początku i wynikiem będą zajęcia w godzinach
	/// zgodnych z rzeczywistymi.
	/// 
	/// Dla bloku dwugodzinnego, trwającego od 9:15 do 11:00 z 15 minutową przerwą od 10:00 do 10:15, reprezentowanego
	/// jako zajęcia od 9:00 do 11:00, modyfikator wyprodukuje dwa zajęcia - 9:15 - 10:00 oraz 10:15 - 11:00.
	/// 
	/// Na PW sztandarowym wyjątkiem od reguły są zajęcia WF-u, trwające 90 minut bez przerwy. Modyfikator nie zmieni
	/// takich zajęć, ponieważ bierze pod uwagę tylko te, które trwają co najmniej 60 minut(<see cref="BreakDuration" />
	/// + <see cref="ClassesDuration"/>) i są wielokrotnością tej liczby(60, 120, 180, ...).
	/// </remarks>
	public sealed class AddBreaks
		: ICalendarModifier
	{
		/// <summary>
		/// Określa ile minut trwa przerwa.
		/// </summary>
		public int BreakDuration { get; set; }

		/// <summary>
		/// Określa ile minut mają trwać pojedyncze zajęcia.
		/// </summary>
		public int ClassesDuration { get; set; }

		/// <summary>
		/// Określa, czy dodać przerwę na początku zajęć(domyślnie - na końcu).
		/// </summary>
		public bool AddAtBeginning { get; set; }

		/// <inheritdoc />
		public IntermediateCalendar Apply(IntermediateCalendar data, GenerationContext context)
		{
			var singleClasses = this.BreakDuration + this.ClassesDuration;

			var classes = data.Weeks
				.SelectMany(w => w.Days)
				.SelectMany(d => d.Classes.Select(c => new
					{
						Day = d,
						Classes = c,
						Time = Period.Between(c.StartDate, c.EndDate, PeriodUnits.Minutes).Minutes
					})
				)
				.Where(c => c.Time >= singleClasses && c.Time % singleClasses == 0)
				.ToList();

			foreach (var c in classes)
			{
				var copiesCount = (int)(c.Time / singleClasses);
				var copies = Duplicate(c.Classes, copiesCount);

				var startDate = c.Classes.StartDate;
				foreach (var copy in copies)
				{
					var endDate = startDate.PlusMinutes(this.ClassesDuration);
					if (this.AddAtBeginning)
					{
						endDate = endDate.PlusMinutes(this.BreakDuration);
						startDate = startDate.PlusMinutes(this.BreakDuration);
					}

					copy.StartDate = startDate;
					copy.EndDate = endDate;

					startDate = this.AddAtBeginning ? endDate : endDate.PlusMinutes(this.BreakDuration);
				}

				c.Day.Classes.Remove(c.Classes);
				c.Day.Classes.AddRange(copies);
			}

			return data;
		}

		private static IntermediateClasses Duplicate(IntermediateClasses classes)
		{
			return new IntermediateClasses
			{
				StartDate = classes.StartDate,
				EndDate = classes.EndDate,
				ShortName = classes.ShortName,
				FullName = classes.FullName,
				Notes = classes.Notes,
				Lecturer = new IntermediateLecturer
				{
					FirstName = classes.Lecturer.FirstName,
					LastName = classes.Lecturer.LastName,
					PhoneNumber = classes.Lecturer.LastName
				},
				Location = new IntermediateLocation
				{
					Name = classes.Location.Name,
					Address = classes.Location.Address,
					Room = classes.Location.Room
				}
			};
		}

		/// <summary>
		/// Tworzy <paramref name="count"/> - 1 kopii obiektu i zwraca listę
		/// zawierającą przekazany obiekt i jego kopie.
		/// </summary>
		/// <param name="classes"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		private static List<IntermediateClasses> Duplicate(IntermediateClasses classes, int count)
		{
			var dups = Enumerable.Range(0, count - 1).Select(_ => Duplicate(classes));
			return new[] { classes }.Concat(dups).ToList();
		}
	}
}
