using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Storage;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Podstawowa implementacja <see cref="ICalendarsManager"/>
	/// </summary>
	public sealed class CalendarsManager
		: ICalendarsManager
	{
		private readonly IContentProvider ContentProvider;
		private readonly IGenerationEngine GenerationEngine;

		private bool IsInitialized;

		/// <inheritdoc />
		public CalendarEntry ActiveEntry { get; private set; }

		/// <inheritdoc />
		public FinalCalendar ActiveCalendar
		{
			get
			{
				return this.GenerationResults != null ? this.GenerationResults.Calendar : null;
			}
		}

		/// <inheritdoc />
		public GenerationResults GenerationResults { get; private set; }

		/// <inheritdoc />
		public IReadOnlyList<CalendarEntry> Entries { get; private set; }

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="contentProvider"></param>
		/// <param name="generationEngine"></param>
		public CalendarsManager(IContentProvider contentProvider, IGenerationEngine generationEngine)
		{
			this.ContentProvider = contentProvider;
			this.GenerationEngine = generationEngine;
		}

		/// <inheritdoc />
		public async Task Initialize()
		{
			if (this.IsInitialized)
			{
				throw new InvalidOperationException();
			}
			this.IsInitialized = true;

			this.Entries = await this.ContentProvider.LoadCalendars() ?? new CalendarEntry[0];
			this.ActiveEntry = this.Entries.FirstOrDefault(e => e.IsActive);
			if (this.ActiveEntry != null)
			{
				await this.RegenerateActiveCalendar();
			}
		}

		private async Task RegenerateActiveCalendar()
		{
			var template = await this.ContentProvider.LoadTemplate(this.ActiveEntry.Id);
			this.GenerationResults = await Task.Run(() => this.GenerationEngine.Generate(template));
		}
	}
}
