using System;

namespace Hertzole.ALE
{
    public interface ILevelEditorNotificationModal
    {
        void Show(string title, string text, string okayButton, Action onClickOkay);

        void Show(string title, string text, string yesButton, string noButton, Action onClickYes, Action onClickNo);
    }
}
