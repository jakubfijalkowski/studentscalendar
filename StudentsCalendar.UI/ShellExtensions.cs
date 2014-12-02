﻿using System;
using System.Reflection;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI.ModifierViewModels;

namespace StudentsCalendar.UI
{
	/// <summary>
	/// Rozszerzenie <see cref="IShell"/>.
	/// </summary>
	public static class ShellExtensions
	{
		/// <summary>
		/// Wyświetla okno edycji modyfikatora.
		/// </summary>
		/// <param name="shell"></param>
		/// <param name="modifier"></param>
		/// <returns></returns>
		public static Popups.PopupBaseViewModel<bool> ShowModifierEditPopup(this IShell shell, IModifier modifier)
		{
			var type = modifier.GetType();
			var baseModelType = typeof(BaseModifierViewModel<>).MakeGenericType(type);
			var method = typeof(IShell).GetRuntimeMethod("ShowPopup", new Type[0]).MakeGenericMethod(baseModelType);
			var vm = (IModifierViewModel)method.Invoke(shell, new object[0]);
			vm.Modifier = modifier;
			return (Popups.PopupBaseViewModel<bool>)vm;
		}
	}
}
