using System.Threading.Tasks;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Generation;
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
		public CurrentCalendar(IContentProvider contentProvider, IGenerationEngine generationEngine)
		{
			this.ContentProvider = contentProvider;
			this.GenerationEngine = generationEngine;
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
			this.Template = await this.ContentProvider.LoadTemplate(calendarId);
			this.Results = await Task.Run(() => this.GenerationEngine.Generate(this.Template));
		}
	}
}
