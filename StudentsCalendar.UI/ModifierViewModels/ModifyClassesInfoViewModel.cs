using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ModifierViewModels
{
	/// <summary>
	/// VM dla modyfikatora <see cref="ModifyClassesInfo"/>.
	/// </summary>
	public sealed class ModifyClassesInfoViewModel
		: BaseModifierViewModel<ModifyClassesInfo>
	{
		public bool HasStartTime { get; set; }

		public bool HasEndTime { get; set; }

		public bool HasShortName { get; set; }

		public bool HasFullName { get; set; }

		public bool HasNotes { get; set; }
		public ModifyClassesInfoViewModel(IDataProvider dataProvider, IActivitySpanRenderer spanRenderer)
			: base(dataProvider, spanRenderer)
		{ }

		public override void Save()
		{
			if (!this.HasStartTime)
			{
				this.Modifier.StartTime = null;
			}
			if (!this.HasEndTime)
			{
				this.Modifier.EndTime = null;
			}
			if (!this.HasShortName)
			{
				this.Modifier.ShortName = null;
			}
			if (!this.HasFullName)
			{
				this.Modifier.FullName = null;
			}
			if (!this.HasNotes)
			{
				this.Modifier.Notes = null;
			}
			base.Save();
		}

		protected override void OnModifierChanged()
		{
			this.HasStartTime = this.Modifier.StartTime.HasValue;
			this.HasEndTime = this.Modifier.EndTime.HasValue;
			this.HasShortName = this.Modifier.ShortName != null;
			this.HasFullName = this.Modifier.FullName != null;
			this.HasNotes = this.Modifier.Notes != null;

			this.Refresh();
		}
	}
}
