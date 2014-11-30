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
			get { return this.Results.Calendar; }
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
		public async Task Update(string calendarId)
		{
			var template = await this.ContentProvider.LoadTemplate(calendarId);
			var results = this.GenerationEngine.Generate(template);

			this.Template = template;
			this.Results = results;
		}
	}
}
