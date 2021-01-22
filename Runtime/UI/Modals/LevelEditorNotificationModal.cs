using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class LevelEditorNotificationModal : MonoBehaviour, ILevelEditorNotificationModal
    {
        [SerializeField]
        private TextMeshProUGUI title = null;
        [SerializeField]
        private TextMeshProUGUI text = null;

        [Space]

        [SerializeField]
        private Button yesButton = null;
        [SerializeField]
        private TextMeshProUGUI yesButtonLabel = null;
        [SerializeField]
        private Button noButton = null;
        [SerializeField]
        private TextMeshProUGUI noButtonLabel = null;

        private Action clickYes;
        private Action clickNo;

        private void Awake()
        {
            yesButton.onClick.AddListener(() => clickYes?.Invoke());
            noButton.onClick.AddListener(() => clickNo?.Invoke());
        }

        public void Show(string title, string text, string okayButton, Action onClickOkay)
        {
            noButton.gameObject.SetActive(false);
            this.title.text = title;
            this.text.text = text;

            yesButtonLabel.text = okayButton;
            clickYes = onClickOkay;
            clickNo = null;
        }

        public void Show(string title, string text, string yesButton, string noButton, Action onClickYes, Action onClickNo)
        {
            this.title.text = title;
            this.text.text = text;

            this.yesButton.gameObject.SetActive(onClickYes != null);
            this.noButton.gameObject.SetActive(onClickNo != null);

            yesButtonLabel.text = yesButton;
            noButtonLabel.text = noButton;
            clickYes = onClickYes;
            clickNo = onClickNo;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void Reset()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
            if (yesButtonLabel == null && yesButton != null)
            {
                yesButtonLabel = yesButton.GetComponentInChildren<TextMeshProUGUI>();
            }

            if (noButtonLabel == null && noButton != null)
            {
                noButtonLabel = noButton.GetComponentInChildren<TextMeshProUGUI>();
            }
        }
#endif
    }
}
