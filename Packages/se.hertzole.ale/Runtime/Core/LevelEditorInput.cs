using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    //TODO: Make sure inputs exist.
    public class LevelEditorInput : MonoBehaviour, ILevelEditorInput
    {
        [SerializeField]
        private InputItem[] inputs = null;

        private Dictionary<string, InputItem> inputLookup;

        public Vector2 MousePosition { get { return Input.mousePosition; } }

        private void Awake()
        {
            inputLookup = new Dictionary<string, InputItem>();
            for (int i = 0; i < inputs.Length; i++)
            {
                inputLookup.Add(inputs[i].name, inputs[i]);
            }
        }

        public bool GetButton(string action)
        {
            return Input.GetButton(inputLookup[action].action);
        }

        public bool GetButtonDown(string action)
        {
            return Input.GetButtonDown(inputLookup[action].action);
        }

        public bool GetButtonUp(string action)
        {
            return Input.GetButtonUp(inputLookup[action].action);
        }

        public float GetAxis(string action, bool raw)
        {
            return raw ? Input.GetAxisRaw(inputLookup[action].action) : Input.GetAxis(inputLookup[action].action);
        }

        public Vector2 GetVector2(string action, bool raw)
        {
            InputItem input = inputLookup[action];
            return new Vector2(raw ? Input.GetAxisRaw(input.action) : Input.GetAxis(input.action), raw ? Input.GetAxisRaw(input.action2) : Input.GetAxis(input.action2));
        }

        public bool IsMouseOverUI()
        {
            return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
        }
    }

    [Serializable]
    public sealed class InputItem : IEquatable<InputItem>
    {
        public enum InputType { Button, Axis, Vector2 }

        public string name;
        public InputType type;
        public string action;
        public string action2;

        public override bool Equals(object obj)
        {
            return Equals(obj as InputItem);
        }

        public bool Equals(InputItem other)
        {
            return other != null && type == other.type && name == other.name && action == other.action && action2 == other.action2;
        }

        public override int GetHashCode()
        {
            int hashCode = 914879481;
            hashCode = hashCode * -1521134295 + type.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(action);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(action2);
            return hashCode;
        }

        public static bool operator ==(InputItem left, InputItem right)
        {
            return EqualityComparer<InputItem>.Default.Equals(left, right);
        }

        public static bool operator !=(InputItem left, InputItem right)
        {
            return !(left == right);
        }
    }
}
