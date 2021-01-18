using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class TreeItemExpander : Selectable, IPointerClickHandler, ISubmitHandler, ICanvasElement
    {
        [Serializable]
        public class ExpandEvent : UnityEvent<bool> { }

#if UNITY_EDITOR
        [Space]
#endif

        [SerializeField]
        private float fadeTime = 0.1f;
        [SerializeField]
        private Graphic collapsedGraphic = null;
        [SerializeField]
        private Graphic expandedGraphic = null;

#if UNITY_EDITOR
        [Space]
#endif

        [SerializeField]
        private bool isExpanded = false;

#if UNITY_EDITOR
        [Space]
#endif

        [SerializeField]
        private ExpandEvent onValueChanged = new ExpandEvent();

        private bool canExpand;

        public bool CanExpand { get { return canExpand; } set { canExpand = value; UpdateState(); } }
        public bool IsExpanded { get { return isExpanded; } set { Set(value); } }

        public float FadeTime { get { return fadeTime; } set { fadeTime = value; } }

        public Graphic CollapsedGraphic { get { return collapsedGraphic; } set { collapsedGraphic = value; } }
        public Graphic ExpandedGraphic { get { return expandedGraphic; } set { expandedGraphic = value; } }

        public ExpandEvent OnValueChanged { get { return onValueChanged; } }

        private void UpdateState()
        {
            if (canExpand)
            {
                interactable = true;
                collapsedGraphic.gameObject.SetActive(true);
                expandedGraphic.gameObject.SetActive(true);
            }
            else
            {
                interactable = false;
                collapsedGraphic.gameObject.SetActive(false);
                expandedGraphic.gameObject.SetActive(false);
            }
        }

        protected override void Awake()
        {
            base.Awake();

            UpdateState();
        }

        protected override void Start()
        {
            PlayEffect(true);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            PlayEffect(true);
        }

        protected virtual void PlayEffect(bool instant)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                if (expandedGraphic != null)
                {
                    expandedGraphic.canvasRenderer.SetAlpha(isExpanded ? 1f : 0);
                }

                if (collapsedGraphic != null)
                {
                    collapsedGraphic.canvasRenderer.SetAlpha(isExpanded ? 0f : 0);
                }
            }
            else
#endif
                DoExpandCollapseAnimation(isExpanded, instant);
        }

        protected virtual void DoExpandCollapseAnimation(bool isExpanded, bool instant)
        {
            if (expandedGraphic != null)
            {
                expandedGraphic.CrossFadeAlpha(isExpanded ? 1f : 0f, instant ? 0f : fadeTime, true);
            }

            if (collapsedGraphic != null)
            {
                collapsedGraphic.CrossFadeAlpha(isExpanded ? 0f : 1f, instant ? 0f : fadeTime, true);
            }
        }

        public void SetIsExpandedWithoutNotify(bool value)
        {
            Set(value, false);
        }

        private void Set(bool value, bool sendCallback = true)
        {
            //if (isExpanded == value)
            //{
            //    return;
            //}

            isExpanded = value;
            PlayEffect(fadeTime <= 0);
            if (sendCallback)
            {
                UISystemProfilerApi.AddMarker("TreeItemExpander.value", this);
                onValueChanged?.Invoke(isExpanded);
            }
            UpdateState();
        }

        private void InternalToggle()
        {
            if (!IsActive() || !IsInteractable())
            {
                return;
            }

            IsExpanded = !isExpanded;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            InternalToggle();
        }

        public void OnSubmit(BaseEventData eventData)
        {
            InternalToggle();
        }

        public void Rebuild(CanvasUpdate executing)
        {
#if UNITY_EDITOR
            if (executing == CanvasUpdate.Prelayout)
            {
                onValueChanged.Invoke(isExpanded);
            }
#endif
        }

        public void LayoutComplete() { }

        public void GraphicUpdateComplete() { }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();

            if (!UnityEditor.PrefabUtility.IsPartOfPrefabAsset(this) && !Application.isPlaying)
            {
                CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);
            }
        }
#endif
    }
}
