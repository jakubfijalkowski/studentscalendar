﻿using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Bazowy interfejs dla modyfikatorów zajęć/wykładów.
	/// Operuje na <see cref="IntermediateClasses"/>.
	/// </summary>
	public interface IClassesModifier
	{
		/// <summary>
		/// Przedział aktywności, kiedy dany modyfikator ma być aktywny.
		/// </summary>
		IActivitySpan ActivitySpan { get; set; }

		/// <summary>
		/// Aplikuje modyfikator na danych.
		/// </summary>
		/// <param name="data"></param>
		void Apply(IntermediateClasses data);
	}
}
