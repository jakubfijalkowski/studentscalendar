using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ModifierViewModels
{
	/// <summary>
	/// VM dla modyfikatora <see cref="ModifyLecturerInfo"/>.
	/// </summary>
	public sealed class ModifyLecturerInfoViewModel
		: BaseModifierViewModel<ModifyLecturerInfo>
	{
		public bool HasFirstName { get; set; }

		public bool HasLastName { get; set; }

		public bool HasPhoneNumber { get; set; }
		public ModifyLecturerInfoViewModel(IDataProvider dataProvider, IActivitySpanRenderer spanRenderer)
			: base(dataProvider, spanRenderer)
		{ }

		public override void Save()
		{
			if (!this.HasFirstName)
			{
				this.Modifier.FirstName = null;
			}
			if (!this.HasLastName)
			{
				this.Modifier.LastName = null;
			}
			if (!this.HasPhoneNumber)
			{
				this.Modifier.PhoneNumber = null;
			}
			base.Save();
		}

		protected override void OnModifierChanged()
		{
			this.HasFirstName = this.Modifier.FirstName != null;
			this.HasLastName = this.Modifier.LastName != null;
			this.HasPhoneNumber = this.Modifier.PhoneNumber != null;

			this.Refresh();
		}
	}
}
