using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class LevelEditorMessageModal : MonoBehaviour, ILevelEditorMessageModal
    {
        [Header("Labels")]
        [SerializeField] 
        private TextMeshProUGUI titleLabel = default;
        [SerializeField] 
        private TextMeshProUGUI messageLabel = default;

        [Header("Buttons")]
        [SerializeField] 
        private Button closeButton = default;
        [SerializeField] 
        private Button confirmButton = default;
        [SerializeField] 
        private TextMeshProUGUI confirmButtonLabel = default;
        [SerializeField] 
        private Button declineButton = default;
        [SerializeField] 
        private TextMeshProUGUI declineButtonLabel = default;
        [SerializeField] 
        private Button alternativeButton = default;
        [SerializeField] 
        private TextMeshProUGUI alternativeButtonLabel = default;

        private bool closeOnConfirm;
        private bool closeOnDecline;
        private bool closeOnAlternative;
        
        private Action confirmAction;
        private Action declineAction;
        private Action alternativeAction;
        
        GameObject ILevelEditorModal.MyGameObject { get { return gameObject; } }
      
        public event Action OnClose;

        private void Awake()
        {
            if (confirmButton != null)
            {
                confirmButton.onClick.AddListener(OnClickConfirm);
            }
            
            if (declineButton != null)
            {
                declineButton.onClick.AddListener(OnClickDecline);
            }
            
            if (alternativeButton != null)
            {
                alternativeButton.onClick.AddListener(OnClickAlternative);
            }

            if (closeButton != null)
            {
                closeButton.onClick.AddListener(OnClickCloseButton);
            }
        }

        private void OnClickConfirm()
        {
            if (closeOnConfirm)
            {
                Close();
            }
            
            confirmAction?.Invoke();
        }

        private void OnClickDecline()
        {
            if (closeOnDecline)
            {
                Close();
            }
            
            declineAction?.Invoke();
        }

        private void OnClickAlternative()
        {
            if (closeOnAlternative)
            {
                Close();
            }
            
            alternativeAction?.Invoke();
        }

        private void OnClickCloseButton()
        {
            OnClose?.Invoke();
        }
        
        public void Close()
        {
            OnClose?.Invoke();
        }

        public void ShowMessage(string title, string message, string okayButtonText = null, bool closeOnClickOkay = true, Action onClickOkay = null)
        {
            ShowTitleAndMessage(title, message);
            ShowButton(confirmButton, confirmButtonLabel, okayButtonText);
            ToggleButton(declineButton, false);
            ToggleButton(alternativeButton, false);

            closeOnConfirm = closeOnClickOkay;
            confirmAction = onClickOkay;
        }

        public void ShowPrompt(string title, string message, string confirmText = "Yes", string declineText = "No", string alternativeText = null, 
            bool closeOnClickConfirm = true, bool closeOnClickDecline = true, bool closeOnClickAlternative = true,
            Action onClickConfirm = null, Action onClickDecline = null, Action onClickAlternative = null)
        {
            ShowTitleAndMessage(title, message);
            ShowButton(confirmButton, confirmButtonLabel, confirmText);
            ShowButton(declineButton, declineButtonLabel, declineText);
            ShowButton(alternativeButton, alternativeButtonLabel, alternativeText);

            closeOnConfirm = closeOnClickConfirm;
            closeOnDecline = closeOnClickDecline;
            closeOnAlternative = closeOnClickAlternative;

            confirmAction = onClickConfirm;
            declineAction = onClickDecline;
            alternativeAction = onClickAlternative;
        }

        private void ShowTitleAndMessage(string title, string message)
        {
            if (title != null)
            {
                if (string.IsNullOrEmpty(title))
                {
                    titleLabel.gameObject.SetActive(false);
                }
                else
                {
                    titleLabel.text = title;
                    titleLabel.gameObject.SetActive(true);
                }
            }

            if (messageLabel != null)
            {
                if (string.IsNullOrEmpty(message))
                {
                    messageLabel.gameObject.SetActive(false);
                }
                else
                {
                    messageLabel.text = message;
                    messageLabel.gameObject.SetActive(true);
                }
            }
        }

        private static void ShowButton(Component button, TMP_Text label, string buttonText)
        {
            if (button != null)
            {
                if (string.IsNullOrEmpty(buttonText))
                {
                    button.gameObject.SetActive(false);
                }
                else
                {
                    if (label != null)
                    {
                        label.text = buttonText;
                    }

                    button.gameObject.SetActive(true);
                }
            }
        }

        private static void ToggleButton(Component button, bool toggle)
        {
            if (button != null)
            {
                button.gameObject.SetActive(toggle);
            }
        }

#if UNITY_EDITOR
        private void Reset()
        {
            GetStandardComponents();
        }

        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
            if (confirmButton != null && confirmButtonLabel == null)
            {
                confirmButtonLabel = confirmButton.GetComponentInChildren<TextMeshProUGUI>();
            }

            if (declineButton != null && declineButtonLabel == null)
            {
                declineButtonLabel = declineButton.GetComponentInChildren<TextMeshProUGUI>();
            }

            if (alternativeButton != null && alternativeButtonLabel == null)
            {
                alternativeButtonLabel = alternativeButton.GetComponentInChildren<TextMeshProUGUI>();
            }
        }
#endif
    }
}
