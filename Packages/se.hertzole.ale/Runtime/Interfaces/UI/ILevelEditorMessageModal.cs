using System;

namespace Hertzole.ALE
{
	public interface ILevelEditorMessageModal : ILevelEditorModal
	{
		void ShowMessage(string title, string message, string okayButtonText = null, bool closeOnClickOkay = true, Action onClickOkay = null);

		void ShowPrompt(string title,
			string message,
			string confirmText = "Yes",
			string declineText = "No",
			string alternativeText = null,
			bool closeOnClickConfirm = true,
			bool closeOnClickDecline = true,
			bool closeOnClickAlternative = true,
			Action onClickConfirm = null,
			Action onClickDecline = null,
			Action onClickAlternative = null);
	}
}