using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ModifierViewModels
{
	/// <summary>
	/// VM dla modyfikatora <see cref="ModifyLocationInfo"/>.
	/// </summary>
	public sealed class ModifyLocationInfoViewModel
		: BaseModifierViewModel<ModifyLocationInfo>
	{
		public bool HasName { get; set; }

		public bool HasAddress { get; set; }

		public bool HasRoom { get; set; }

		public ModifyLocationInfoViewModel(IDataProvider dataProvider, IActivitySpanEditor editor)
			: base(dataProvider, editor)
		{ }

		public override void Save()
		{
			if (!this.HasName)
			{
				this.Modifier.Name = null;
			}
			if (!this.HasAddress)
			{
				this.Modifier.Address = null;
			}
			if (!this.HasRoom)
			{
				this.Modifier.Room = null;
			}
			base.Save();
		}

		protected override void OnModifierChanged()
		{
			this.HasName = this.Modifier.Name != null;
			this.HasAddress = this.Modifier.Address != null;
			this.HasRoom = this.Modifier.Room != null;

			this.Refresh();
		}
	}
}
