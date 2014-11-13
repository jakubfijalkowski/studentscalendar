using System;
using System.Linq;
using System.Reflection;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// Rozszerzenia związane z filtrowaniem <see cref="Type"/>.
	/// </summary>
	static class TypeExtensions
	{
		/// <summary>
		/// Sprawdza, czy klasa implementuje wskazany interfejs.
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool Implements<TInterface>(this Type type)
		{
			return type.GetInterfaces().Any(t => t == typeof(TInterface));
		}

		/// <summary>
		/// Sprawdza, czy klasa dziedziczy po wskazanej klasie.
		/// </summary>
		/// <typeparam name="TBaseClass"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool Inherits<TBaseClass>(this Type type)
		{
			var baseType = typeof(TBaseClass);
			do
			{
				type = type.BaseType;
			}
			while (type != null && type != baseType);
			return type == baseType;
		}

		/// <summary>
		/// Sprawdza, czy klasa posiada wskazany atrybut.
		/// </summary>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool HasAttribute<TAttribute>(this Type type)
			where TAttribute : Attribute
		{
			return type.GetCustomAttribute<TAttribute>() != null;
		}
	}
}
