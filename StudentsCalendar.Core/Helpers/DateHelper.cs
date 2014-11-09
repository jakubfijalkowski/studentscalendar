﻿using System;
using System.Linq;
using NodaTime;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Udostępnia kilka właściwości ułatwiających pracę z NodaTime.
	/// </summary>
	public static class DateHelper
	{
		private static Lazy<DateTimeZone> _SystemZone = new Lazy<DateTimeZone>(RetrieveSystemZone);

		/// <summary>
		/// Pobiera systemową strefę czasową.
		/// </summary>
		public static DateTimeZone SystemZone
		{
			get { return _SystemZone.Value; }
		}

		/// <summary>
		/// Pobiera aktualny czas, w systemowej strefie czasowej, skonwertowany na <see cref="LocalDateTime"/>.
		/// </summary>
		public static LocalDateTime Now
		{
			get
			{
				return SystemClock.Instance.Now.InZone(SystemZone).LocalDateTime;
			}
		}

		/// <summary>
		/// Pobiera datę aktualnego dnia w systemowej strefie czasowej.
		/// </summary>
		public static LocalDate Today
		{
			get
			{
				return SystemClock.Instance.Now.InZone(SystemZone).Date;
			}
		}

		/// <summary>
		/// Wybiera minimalną wartość z podanych.
		/// </summary>
		/// <param name="dates"></param>
		/// <returns></returns>
		public static LocalTime Min(params LocalTime[] dates)
		{
			return dates.Min();
		}

		/// <summary>
		/// Wybiera maksymalną wartość z podanych.
		/// </summary>
		/// <param name="dates"></param>
		/// <returns></returns>
		public static LocalTime Max(params LocalTime[] dates)
		{
			return dates.Max();
		}

		private static DateTimeZone RetrieveSystemZone()
		{
			try
			{
				return DateTimeZoneProviders.Tzdb.GetSystemDefault();
			}
			catch
			{
				return DateTimeZone.Utc;
			}
		}
	}
}
