﻿#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP
#endif

#if !STRIP
using TMPro;
using UnityEngine;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#if !OBSOLETE
    [AddComponentMenu("ALE/UI/uGUI/Component UI", 10)]
#else
    [System.Obsolete("LevelEditorComponentUI will be stripped on build.", true)]
#endif
#endif
    public class LevelEditorComponentUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI titleLabel = null;
        [SerializeField]
        private RectTransform fieldsHolder = null;

        public string Title { get { return titleLabel == null ? string.Empty : titleLabel.text; } set { if (titleLabel != null) { titleLabel.text = value; } } }

        public RectTransform FieldHolder { get { if (fieldsHolder == null) { fieldsHolder = (RectTransform)transform; } return fieldsHolder; } }
        
        public LevelEditorComponentEditor Editor { get; set; }

#if OBSOLETE
        private void Awake()
        {
            Debug.LogError($"{gameObject.name} is still using {nameof(LevelEditorComponentUI)} and it will be stripped on build. Remove it.");
        }
#endif
    }
}
#endif
