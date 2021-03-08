#if !ENABLE_INPUT_SYSTEM || !ALE_NEW_INPUT
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR // If it's obsolete and not in the editor, remove it.
#define STRIP
#endif

#if !STRIP
using UnityEngine;
using UnityEngine.EventSystems;
using System;
#if !OBSOLETE
using UnityEngine.Serialization;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
#endif

namespace Hertzole.ALE
{
#if OBSOLETE
    [System.Obsolete("You're not using the new Input System so this component will be useless.")]
    [AddComponentMenu("")]
#else
    [DisallowMultipleComponent]
#endif
    public class LevelEditorInputSystem : MonoBehaviour, ILevelEditorInput
    {
#if !OBSOLETE
        [SerializeField]
        [FormerlySerializedAs("input")]
        [Tooltip("The input asset to get all actions from.")]
        private InputActionAsset inputAsset = null;
        [SerializeField]
        [Tooltip("All the available actions.")]
        private InputSystemItem[] actions = null;
#endif
        [SerializeField]
        [Tooltip("If true, all actions will be enabled on enable.")]
        private bool autoEnableInput = true;
        [SerializeField]
        [Tooltip("If true, all actions will be disabled on disable.")]
        private bool autoDisableInput = true;

        private bool enabledInput = false;

#if !OBSOLETE
#if UNITY_EDITOR
        [System.Obsolete("Use 'InputAsset' instead. This will be removed on build.", true)]
        public InputActionAsset Input { get { return InputAsset; } set { InputAsset = value; } }
#endif
        /// <summary> The input asset to get all actions from. </summary>
        public InputActionAsset InputAsset { get { return inputAsset; } set { inputAsset = value; } }
        private Dictionary<string, InputAction> actionsDictionary;
#endif

        /// <summary> Has input been enabled? </summary>
        public bool EnabledInput { get { return enabledInput; } }
        /// <summary> If true, all actions will be enabled on enable. </summary>
        public bool AutoEnableInput { get { return autoEnableInput; } set { autoEnableInput = value; } }
        /// <summary> If true, all actions will be disabled on disable. </summary>
        public bool AutoDisableInput { get { return autoDisableInput; } set { autoDisableInput = value; } }

        public Vector2 MousePosition { get { return Mouse.current.position.ReadValue(); } }

#if !OBSOLETE
        /// <summary> All the available actions. </summary>
        public InputSystemItem[] Actions { get { return actions; } set { actions = value; } }
#endif

        private void Start()
        {
#if OBSOLETE
            Debug.LogError(gameObject.name + " has LevelEditorInputSystem added. It does not work on the legacy input manager.");
#else
            UpdateActions();
#endif
        }

        /// <summary>
        /// Enables all actions.
        /// </summary>
        public void EnableInput()
        {
#if !OBSOLETE
            if (actions != null)
            {
                for (int i = 0; i < actions.Length; i++)
                {
                    // Put in DEBUG or Unity editor because we don't want this in release builds in order to improve performance.
#if DEBUG || UNITY_EDITOR
                    // If the action doesn't exist, complain.
                    if (actions[i].action == null)
                    {
                        Debug.LogWarning("There's no action asset present on " + actions[i].actionName + ". It will not be enabled.", gameObject);
                        continue;
                    }
#endif
                    actions[i].action.action.Enable();
                }
                enabledInput = true;
            }
#endif
        }

        /// <summary>
        /// Disables all actions.
        /// </summary>
        public void DisableInput()
        {
#if !OBSOLETE
            if (actions != null)
            {
                for (int i = 0; i < actions.Length; i++)
                {
                    // Put in DEBUG or Unity editor because we don't want this in release builds in order to improve performance.
#if DEBUG || UNITY_EDITOR
                    // If the action doesn't exist, complain.
                    if (actions[i].action == null)
                    {
                        Debug.LogWarning("There's no action asset present on " + actions[i].actionName + ". It will not be disabled.", gameObject);
                        continue;
                    }
#endif
                    actions[i].action.action.Disable();
                }
                enabledInput = false;
            }
#endif
        }

        /// <summary>
        /// Enables a specific action.
        /// </summary>
        /// <param name="actionName">The action by name to enable.</param>
        public void EnableAction(string actionName)
        {
#if !OBSOLETE
            // Put in DEBUG or Unity editor because we don't want this in release builds in order to improve performance.
#if DEBUG || UNITY_EDITOR
            // If the action doesn't exist, complain.
            if (!actionsDictionary.ContainsKey(actionName))
            {
                throw new System.ArgumentException("There's no action called '" + actionName + "' on " + gameObject.name + ".");
            }

            // If there's no action, complain.
            if (actionsDictionary[actionName] == null)
            {
                Debug.LogWarning("There's no action asset present on " + actionsDictionary[actionName] + ".", gameObject);
                return;
            }
#endif // DEBUG || UNITY_EDITOR
            actionsDictionary[actionName].Enable();
#endif // !OBSOLETE
        }

        /// <summary>
        /// Enables a specific action.
        /// </summary>
        /// <param name="actionIndex">The action by index to enable.</param>
        public void EnableAction(int actionIndex)
        {
#if !OBSOLETE
            // Put in DEBUG or Unity editor because we don't want this in release builds in order to improve performance.
#if DEBUG || UNITY_EDITOR
            // If the index is out of range, complain.
            if (actionIndex < 0 || actionIndex >= actions.Length)
            {
                throw new System.ArgumentOutOfRangeException("actionIndex");
            }

            // If there's no action, complain.
            if (actions[actionIndex].action == null)
            {
                Debug.LogWarning("There's no action asset present on " + actions[actionIndex].actionName + ".", gameObject);
                return;
            }
#endif // DEBUG || UNITY_EDITOR
            actions[actionIndex].action.action.Enable();
#endif // !OBSOLETE
        }

        /// <summary>
        /// Disables a specific action.
        /// </summary>
        /// <param name="actionName">The action by name to disable.</param>
        public void DisableAction(string actionName)
        {
#if !OBSOLETE
            // Put in DEBUG or Unity editor because we don't want this in release builds in order to improve performance.
#if DEBUG || UNITY_EDITOR
            // If the action doesn't exist, complain.
            if (!actionsDictionary.ContainsKey(actionName))
            {
                throw new System.ArgumentException("There's no action called '" + actionName + "' on " + gameObject.name + ".");
            }

            // If there's no action, complain.
            if (actionsDictionary[actionName] == null)
            {
                Debug.LogWarning("There's no action asset present on " + actionsDictionary[actionName] + ".", gameObject);
                return;
            }
#endif // DEBUG || UNITY_EDITOR
            actionsDictionary[actionName].Disable();
#endif // !OBSOLETE
        }

        /// <summary>
        /// Disables a specific action.
        /// </summary>
        /// <param name="actionIndex">The action by index to disable.</param>
        public void DisableAction(int actionIndex)
        {
#if !OBSOLETE
            // Put in DEBUG or Unity editor because we don't want this in release builds in order to improve performance.
#if DEBUG || UNITY_EDITOR
            // If the index is out of range, complain.
            if (actionIndex < 0 || actionIndex >= actions.Length)
            {
                throw new System.ArgumentOutOfRangeException("actionIndex");
            }

            // If there's no action, complain.
            if (actions[actionIndex].action == null)
            {
                Debug.LogWarning("There's no action asset present on " + actions[actionIndex].actionName + ".", gameObject);
                return;
            }
#endif // DEBUG || UNITY_EDITOR
            actions[actionIndex].action.action.Disable();
#endif // !OBSOLETE
        }

#if !OBSOLETE
        private void OnEnable()
        {
            // Enable all input if auto enable input is on.
            if (autoEnableInput)
            {
                EnableInput();
            }
        }

        private void OnDisable()
        {
            // Disable all input if auto disable input is on.
            if (autoDisableInput)
            {
                DisableInput();
            }
        }

        // Add all actions to the actions dictionary.
        public void UpdateActions()
        {
            if (actions == null)
            {
                return;
            }

            actionsDictionary = new Dictionary<string, InputAction>();
            for (int i = 0; i < actions.Length; i++)
            {
                actionsDictionary.Add(actions[i].actionName, actions[i].action);
            }
        }
#endif // !OBSOLETE

        /// <summary>
        /// Returns true while an action is being held down.
        /// </summary>
        /// <param name="buttonName">The action to check.</param>
        public bool GetButton(string buttonName)
        {
#if !OBSOLETE
            // Make sure the action exists.
            if (!DoesActionExist(buttonName))
            {
                return false;
            }

            return actionsDictionary[buttonName].activeControl is ButtonControl button && button.isPressed;
#else
            return false;
#endif
        }

        /// <summary>
        /// Returns true if the action was pressed this frame.
        /// </summary>
        /// <param name="buttonName">The action to check.</param>
        public bool GetButtonDown(string buttonName)
        {
#if !OBSOLETE
            // Make sure the action exists.
            if (!DoesActionExist(buttonName))
            {
                return false;
            }

            return actionsDictionary[buttonName].activeControl is ButtonControl button && button.wasPressedThisFrame;
#else
            return false;
#endif
        }

        /// <summary>
        /// Returns true if the action was released this frame.
        /// </summary>
        /// <param name="buttonName">The action to check.</param>
        public bool GetButtonUp(string buttonName)
        {
#if !OBSOLETE
            // Make sure the action exists.
            if (!DoesActionExist(buttonName))
            {
                return false;
            }

            return actionsDictionary[buttonName].activeControl is ButtonControl button && button.wasReleasedThisFrame;
#else
            return false;
#endif
        }

        /// <summary>
        /// Returns the value of an action axis.
        /// </summary>
        /// <param name="axisName">The action to check.</param>
        public float GetAxis(string axisName, bool raw)
        {
#if !OBSOLETE
            // Make sure the action exists.
            if (!DoesActionExist(axisName, true))
            {
                return 0;
            }

            return actionsDictionary[axisName].ReadValue<float>();
#else
            return 0;
#endif
        }

        /// <summary>
        /// Returns the Vector2 value from an action.
        /// </summary>
        /// <param name="action">The action to check.</param>
        public Vector2 GetVector2(string action, bool raw)
        {
#if !OBSOLETE
            // Make sure the action exists.
            if (!DoesActionExist(action))
            {
                return Vector2.zero;
            }

            return actionsDictionary[action].ReadValue<Vector2>();
#else
            return Vector2.zero;
#endif
        }

#if !OBSOLETE
        private bool DoesActionExist(string action, bool axis = false)
        {
            // Put in DEBUG or Unity editor because we don't want this in release builds in order to improve performance.
#if DEBUG || UNITY_EDITOR
            if (inputAsset == null)
            {
                Debug.LogWarning("There is no input asset on " + gameObject.name + ".", gameObject);
                return false;
            }
#endif

            if (actionsDictionary == null)
            {
                UpdateActions();
            }

            // Put in DEBUG or Unity editor because we don't want this in release builds in order to improve performance.
#if DEBUG || UNITY_EDITOR
            // If there's no action, complain.
            if (!actionsDictionary.ContainsKey(action))
            {
                Debug.LogError("Can't find action '" + action + "' in " + inputAsset.name + ".");
                return false;
            }

            // Check if there's an action asset assigned.
            if (actionsDictionary[action] == null)
            {
                Debug.LogError("There's no action assigned on '" + action + "'.", gameObject);
                return false;
            }
#endif

            if (actionsDictionary[action].activeControl == null)
            {
                return false;
            }

#if DEBUG || UNITY_EDITOR
            // If it's an axis action, make sure the type is an axis.
            if (axis)
            {
                if (!(actionsDictionary[action].activeControl is AxisControl))
                {
                    Debug.LogError(action + " is not an axis type.");
                    return false;
                }
            }
#endif
            return true;
        }

        public bool IsMouseOverUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

#endif // !OBSOLETE

#if UNITY_EDITOR && !OBSOLETE
        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                UpdateActions();

                if (enabledInput)
                {
                    EnableInput();
                }
            }
        }
#endif
    }

    [Serializable]
#if OBSOLETE
    [Obsolete("You're not using the new Input System so this struct will be useless.")]
#endif
    public struct InputSystemItem : IEquatable<InputSystemItem>
    {
#if !OBSOLETE
#pragma warning disable CA2235 // Mark all non-serializable fields
        public string actionName;
        public InputActionReference action;

        public InputSystemItem(string actionName, InputActionReference action)
        {
            this.actionName = actionName;
            this.action = action;
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is InputSystemItem item && Equals(item);
        }

        public bool Equals(InputSystemItem other)
        {
            return other.actionName == actionName && other.action == action;
        }

        public override int GetHashCode()
        {
            return (action.action.name + "." + actionName).GetHashCode();
        }

        public static bool operator ==(InputSystemItem left, InputSystemItem right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InputSystemItem left, InputSystemItem right)
        {
            return !(left == right);
        }
#else
        public bool Equals(InputSystemItem other)
        {
            return false;
        }
#endif // !OBSOLETE

#pragma warning restore CA2235 // Mark all non-serializable fields
    }
}
#endif
