using System;

namespace StudentsCalendar.UI.Events
{
	/// <summary>
	/// Użytkownik chce przejść do innej strony głównej aplikacji.
	/// </summary>
	public sealed class NavigateRequestEvent
	{
		private readonly Type _ScreenType;

		/// <summary>
		/// Pobiera docelowy ViewModel.
		/// </summary>
		public Type ScreenType
		{
			get { return this._ScreenType; }
		}

		private NavigateRequestEvent(Type screenType)
		{
			this._ScreenType = screenType;
		}

		public static NavigateRequestEvent Create<TViewModel>()
			where TViewModel : IMainScreen
		{
			return new NavigateRequestEvent(typeof(TViewModel));
		}
	}
}
