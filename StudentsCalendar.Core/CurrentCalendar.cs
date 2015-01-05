using System;
using System.Threading.Tasks;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Logging;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Domyślna implementacja <see cref="ICurrentCalendar"/>.
	/// </summary>
	public sealed class CurrentCalendar
		: ICurrentCalendar
	{
		private readonly IContentProvider ContentProvider;
		private readonly IGenerationEngine GenerationEngine;
		private readonly ILogger Logger;

		/// <inheritdoc />
		public CalendarTemplate Template { get; private set; }

		/// <inheritdoc />
		public GenerationResults Results { get; private set; }

		/// <inheritdoc />
		public FinalCalendar Calendar
		{
			get { return this.Results != null ? this.Results.Calendar : null; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="contentProvider"></param>
		/// <param name="generationEngine"></param>
		public CurrentCalendar(IContentProvider contentProvider, IGenerationEngine generationEngine, ILogger logger)
		{
			this.ContentProvider = contentProvider;
			this.GenerationEngine = generationEngine;
			this.Logger = logger;
		}

		/// <inheritdoc />
		public Task Update(string calendarId)
		{
			if (this.Template != null && this.Template.Id == calendarId)
			{
				return this.LoadAndGenerate(calendarId);
			}
			return Task.FromResult<object>(null);
		}


		public Task MakeActive(string calendarId)
		{
			return this.LoadAndGenerate(calendarId);
		}

		private async Task LoadAndGenerate(string calendarId)
		{
			try
			{
				this.Template = await this.ContentProvider.LoadTemplate(calendarId);
				this.Results = await Task.Run(() => this.GenerationEngine.Generate(this.Template));
			}
			catch (Exception ex)
			{
				this.Logger.Error(ex, "Cannot update calendar {0} in CurrentCalendar.", calendarId);
				throw;
			}
		}
	}
}
