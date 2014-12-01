using System;
using System.Collections.Generic;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// Opisuje typ, który może być tworzony na żądanie przez użytkownika.
	/// </summary>
	public abstract class BaseDescription<TType>
	{
		private readonly string _Name;
		private readonly Type _Type;

		/// <summary>
		/// Pobiera nazwę danych.
		/// </summary>
		public string Name
		{
			get { return this._Name; }
		}

		/// <summary>
		/// Pobiera typ obiektu.
		/// </summary>
		public Type Type
		{
			get { return this._Type; }
		}

		public BaseDescription(string name, Type type)
		{
			this._Name = name;
			this._Type = type;
		}

		public override string ToString()
		{
			return this.Type.Name + " - " + this.Name;
		}
	}

	public sealed class ClassesModifierDescription
		: BaseDescription<IClassesModifier>
	{
		public ClassesModifierDescription(string name, Type type)
			: base(name, type)
		{ }
	}

	public sealed class DayModifierDescription
		: BaseDescription<IDayModifier>
	{
		public DayModifierDescription(string name, Type type)
			: base(name, type)
		{ }
	}

	public sealed class WeekModifierDescription
		: BaseDescription<IWeekModifier>
	{
		public WeekModifierDescription(string name, Type type)
			: base(name, type)
		{ }
	}

	public sealed class CalendarModifierDescription
		: BaseDescription<ICalendarModifier>
	{
		public CalendarModifierDescription(string name, Type type)
			: base(name, type)
		{ }
	}

	public sealed class DailyActivitySpanDescription
		: BaseDescription<IDailyActivitySpan>
	{
		public DailyActivitySpanDescription(string name, Type type)
			: base(name, type)
		{ }
	}

	public sealed class WeeklyActivitySpanDescription
		: BaseDescription<IWeeklyActivitySpan>
	{
		public WeeklyActivitySpanDescription(string name, Type type)
			: base(name, type)
		{ }
	}

	/// <summary>
	/// Udostępnia listę obiektów, które może tworzyć użytkownik i
	/// sposób na ich utworzenie.
	/// </summary>
	public interface IDataProvider
	{
		/// <summary>
		/// Pobiera listę dostępnych modyfikatorów klas.
		/// </summary>
		IReadOnlyList<ClassesModifierDescription> ClassesModifiers { get; }

		/// <summary>
		/// Pobiera listę dostępnych modyfikatorów dni.
		/// </summary>
		IReadOnlyList<DayModifierDescription> DayModifiers { get; }

		/// <summary>
		/// Pobiera listę dostępnych modyfikatorów tygodni.
		/// </summary>
		IReadOnlyList<WeekModifierDescription> WeekModifiers { get; }

		/// <summary>
		/// Pobiera listę dostępnych modyfikatorów kalendarza.
		/// </summary>
		IReadOnlyList<CalendarModifierDescription> CalendarModifiers { get; }

		/// <summary>
		/// Pobiera listę dostępnych dziennych przedziałów aktywności.
		/// </summary>
		IReadOnlyList<DailyActivitySpanDescription> DailyActivitySpans { get; }

		/// <summary>
		/// Pobiera listę dostępnych tygodniowych przedziałów aktywności.
		/// </summary>
		IReadOnlyList<WeeklyActivitySpanDescription> WeeklyActivitySpans { get; }

		/// <summary>
		/// Tworzy jeden z obiektów opisany przez wskazany obiekt.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="description"></param>
		/// <returns></returns>
		TResult Create<TResult>(BaseDescription<TResult> description);
	}
}
