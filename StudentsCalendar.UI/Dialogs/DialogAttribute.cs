using System;
using System.Reflection;

namespace StudentsCalendar.UI.Dialogs
{
	/// <summary>
	/// Przypisuje kontrolkę UI do abstrakcyjnego typu okna dialogowego.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	public sealed class DialogAttribute
		: Attribute
	{
		private readonly Type _DialogType;

		/// <summary>
		/// Pobiera typ dialogu, który kontrolka obsługuje.
		/// </summary>
		public Type DialogType
		{
			get { return this._DialogType; }
		}

		/// <summary>
		/// Inicjalizuje obiekt odpowiednim atrybutem.
		/// </summary>
		/// <param name="dialogType"></param>
		public DialogAttribute(Type dialogType)
		{
			this._DialogType = dialogType;
		}

		/// <summary>
		/// Pobiera <see cref="DialogType"/> z atrybutu przypisanego do wskazanego typu.
		/// </summary>
		/// <param name="controlType"></param>
		/// <returns></returns>
		public static Type GetDialogType(Type controlType)
		{
			var attrib = controlType.GetTypeInfo().GetCustomAttribute<DialogAttribute>();
			return attrib != null ? attrib.DialogType : null;
		}
	}
}
