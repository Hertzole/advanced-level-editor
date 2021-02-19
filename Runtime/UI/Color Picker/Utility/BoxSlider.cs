using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    [AddComponentMenu("UI/BoxSlider", 35)]
    [RequireComponent(typeof(RectTransform))]
    public class BoxSlider : Selectable, IDragHandler, IInitializePotentialDragHandler, ICanvasElement
    {
        public enum Direction
        {
            LeftToRight,
            RightToLeft,
            BottomToTop,
            TopToBottom,
        }

        [Serializable]
        public class BoxSliderEvent : UnityEvent<float, float> { }

        [SerializeField]
        private RectTransform handleRect;
        public RectTransform HandleRect { get { return handleRect; } set { if (SetClass(ref handleRect, value)) { UpdateCachedReferences(); UpdateVisuals(); } } }

        [Space(6)]

        [SerializeField]
        private float minValue = 0;
        public float MinValue { get { return minValue; } set { if (SetStruct(ref minValue, value)) { Set(this.value); SetY(valueY); UpdateVisuals(); } } }

        [SerializeField]
        private float maxValue = 1;
        public float MaxValue { get { return maxValue; } set { if (SetStruct(ref maxValue, value)) { Set(this.value); SetY(valueY); UpdateVisuals(); } } }

        [SerializeField]
        private bool wholeNumbers = false;
        public bool WholeNumbers { get { return wholeNumbers; } set { if (SetStruct(ref wholeNumbers, value)) { Set(this.value); SetY(valueY); UpdateVisuals(); } } }

        [SerializeField]
        private float value = 1f;
        public float Value
        {
            get
            {
                if (WholeNumbers)
                {
                    return Mathf.Round(value);
                }

                return value;
            }
            set
            {
                Set(value);
            }
        }

        public float NormalizedValue
        {
            get
            {
                if (Mathf.Approximately(MinValue, MaxValue))
                {
                    return 0;
                }

                return Mathf.InverseLerp(MinValue, MaxValue, Value);
            }
            set
            {
                Value = Mathf.Lerp(MinValue, MaxValue, value);
            }
        }

        [SerializeField]
        private float valueY = 1f;
        public float ValueY
        {
            get
            {
                if (WholeNumbers)
                {
                    return Mathf.Round(valueY);
                }

                return valueY;
            }
            set
            {
                SetY(value);
            }
        }

        public float NormalizedValueY
        {
            get
            {
                if (Mathf.Approximately(MinValue, MaxValue))
                {
                    return 0;
                }

                return Mathf.InverseLerp(MinValue, MaxValue, ValueY);
            }
            set
            {
                ValueY = Mathf.Lerp(MinValue, MaxValue, value);
            }
        }

        [Space(6)]

        // Allow for delegate-based subscriptions for faster events than 'eventReceiver', and allowing for multiple receivers.
        [SerializeField]
        private BoxSliderEvent onValueChanged = new BoxSliderEvent();
        public BoxSliderEvent OnValueChanged { get { return onValueChanged; } set { onValueChanged = value; } }
        [SerializeField]
        private BoxSliderEvent onEndEdit = new BoxSliderEvent();
        public BoxSliderEvent OnEndEdit { get { return onEndEdit; } set { onEndEdit = value; } }

        // Private fields

        private float startDragX;
        private float startDragY;

        //private Image m_FillImage;
        //private Transform m_FillTransform;
        //private RectTransform m_FillContainerRect;
        private Transform m_HandleTransform;
        private RectTransform m_HandleContainerRect;

        // The offset from handle position to mouse down position
        private Vector2 m_Offset = Vector2.zero;

        private DrivenRectTransformTracker m_Tracker;

        // Size of each step.
        float stepSize { get { return WholeNumbers ? 1 : (MaxValue - MinValue) * 0.1f; } }

        protected BoxSlider()
        { }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();

            if (WholeNumbers)
            {
                minValue = Mathf.Round(minValue);
                maxValue = Mathf.Round(maxValue);
            }

            //Onvalidate is called before OnEnabled. We need to make sure not to touch any other objects before OnEnable is run.
            if (IsActive())
            {
                UpdateCachedReferences();
                Set(value, false);
                SetY(valueY, false);
                // Update rects since other things might affect them even if value didn't change.
                UpdateVisuals();
            }

#if UNITY_2018_3_OR_NEWER

            if (!UnityEditor.PrefabUtility.IsPartOfPrefabAsset(this) && !Application.isPlaying)
            {
                CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);
            }

#else

            var prefabType = UnityEditor.PrefabUtility.GetPrefabType(this);
			if (prefabType != UnityEditor.PrefabType.Prefab && !Application.isPlaying)
				CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);
#endif
        }
#endif // if UNITY_EDITOR

        public virtual void Rebuild(CanvasUpdate executing)
        {
#if UNITY_EDITOR
            if (executing == CanvasUpdate.Prelayout)
            {
                OnValueChanged.Invoke(Value, ValueY);
            }
#endif
        }

        public void LayoutComplete()
        {

        }

        public void GraphicUpdateComplete()
        {

        }

        public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
        {
            if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
            {
                return false;
            }

            currentValue = newValue;
            return true;
        }

        public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
        {
            if (currentValue.Equals(newValue))
            {
                return false;
            }

            currentValue = newValue;
            return true;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            UpdateCachedReferences();
            Set(value, false);
            SetY(valueY, false);
            // Update rects since they need to be initialized correctly.
            UpdateVisuals();
        }

        protected override void OnDisable()
        {
            m_Tracker.Clear();
            base.OnDisable();
        }

        void UpdateCachedReferences()
        {

            if (handleRect)
            {
                m_HandleTransform = handleRect.transform;
                if (m_HandleTransform.parent != null)
                {
                    m_HandleContainerRect = m_HandleTransform.parent.GetComponent<RectTransform>();
                }
            }
            else
            {
                m_HandleContainerRect = null;
            }
        }

        // Set the valueUpdate the visible Image.
        void Set(float input)
        {
            Set(input, true);
        }

        void Set(float input, bool sendCallback)
        {
            // Clamp the input
            float newValue = Mathf.Clamp(input, MinValue, MaxValue);
            if (WholeNumbers)
            {
                newValue = Mathf.Round(newValue);
            }

            // If the stepped value doesn't match the last one, it's time to update
            if (value.Equals(newValue))
            {
                return;
            }

            value = newValue;
            UpdateVisuals();
            if (sendCallback)
            {
                onValueChanged.Invoke(newValue, ValueY);
            }
        }

        void SetY(float input)
        {
            SetY(input, true);
        }

        void SetY(float input, bool sendCallback)
        {
            // Clamp the input
            float newValue = Mathf.Clamp(input, MinValue, MaxValue);
            if (WholeNumbers)
            {
                newValue = Mathf.Round(newValue);
            }

            // If the stepped value doesn't match the last one, it's time to update
            if (valueY.Equals(newValue))
            {
                return;
            }

            valueY = newValue;
            UpdateVisuals();
            if (sendCallback)
            {
                onValueChanged.Invoke(Value, newValue);
            }
        }


        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            UpdateVisuals();
        }

        enum Axis
        {
            Horizontal = 0,
            Vertical = 1
        }


        // Force-update the slider. Useful if you've changed the properties and want it to update visually.
        private void UpdateVisuals()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                UpdateCachedReferences();
            }
#endif

            m_Tracker.Clear();


            //to business!
            if (m_HandleContainerRect != null)
            {
                m_Tracker.Add(this, handleRect, DrivenTransformProperties.Anchors);
                Vector2 anchorMin = Vector2.zero;
                Vector2 anchorMax = Vector2.one;
                anchorMin[0] = anchorMax[0] = (NormalizedValue);
                anchorMin[1] = anchorMax[1] = (NormalizedValueY);

                handleRect.anchorMin = anchorMin;
                handleRect.anchorMax = anchorMax;
            }
        }

        // Update the slider's position based on the mouse.
        void UpdateDrag(PointerEventData eventData, Camera cam)
        {
            RectTransform clickRect = m_HandleContainerRect;
            if (clickRect != null && clickRect.rect.size[0] > 0)
            {
                if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(clickRect, eventData.position, cam, out Vector2 localCursor))
                {
                    return;
                }

                localCursor -= clickRect.rect.position;

                float val = Mathf.Clamp01((localCursor - m_Offset)[0] / clickRect.rect.size[0]);
                NormalizedValue = (val);

                float valY = Mathf.Clamp01((localCursor - m_Offset)[1] / clickRect.rect.size[1]);
                NormalizedValueY = (valY);

            }
        }

        private bool MayDrag(PointerEventData eventData)
        {
            return IsActive() && IsInteractable() && eventData.button == PointerEventData.InputButton.Left;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (!MayDrag(eventData))
            {
                return;
            }

            base.OnPointerDown(eventData);

            startDragX = Value;
            startDragY = ValueY;

            m_Offset = Vector2.zero;
            if (m_HandleContainerRect != null && RectTransformUtility.RectangleContainsScreenPoint(handleRect, eventData.position, eventData.enterEventCamera))
            {
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(handleRect, eventData.position, eventData.pressEventCamera, out Vector2 localMousePos))
                {
                    m_Offset = localMousePos;
                }

                m_Offset.y = -m_Offset.y;
            }
            else
            {
                // Outside the slider handle - jump to this point instead
                UpdateDrag(eventData, eventData.pressEventCamera);
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            if (startDragX != Value || startDragY != ValueY)
            {
                onEndEdit.Invoke(Value, ValueY);
            }
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            if (!MayDrag(eventData))
            {
                return;
            }

            UpdateDrag(eventData, eventData.pressEventCamera);
        }

        //public override void OnMove(AxisEventData eventData)
        //{
        //    if (!IsActive() || !IsInteractable())
        //    {
        //        base.OnMove(eventData);
        //        return;
        //    }

        //    switch (eventData.moveDir)
        //    {
        //    case MoveDirection.Left:
        //        if (axis == Axis.Horizontal && FindSelectableOnLeft() == null) {
        //            Set(reverseValue ? value + stepSize : value - stepSize);
        //            SetY (reverseValue ? valueY + stepSize : valueY - stepSize);
        //        }
        //        else
        //            base.OnMove(eventData);
        //        break;
        //    case MoveDirection.Right:
        //        if (axis == Axis.Horizontal && FindSelectableOnRight() == null) {
        //            Set(reverseValue ? value - stepSize : value + stepSize);
        //            SetY(reverseValue ? valueY - stepSize : valueY + stepSize);
        //        }
        //        else
        //            base.OnMove(eventData);
        //        break;
        //    case MoveDirection.Up:
        //        if (axis == Axis.Vertical && FindSelectableOnUp() == null) {
        //            Set(reverseValue ? value - stepSize : value + stepSize);
        //            SetY(reverseValue ? valueY - stepSize : valueY + stepSize);
        //        }
        //        else
        //            base.OnMove(eventData);
        //        break;
        //    case MoveDirection.Down:
        //        if (axis == Axis.Vertical && FindSelectableOnDown() == null) {
        //            Set(reverseValue ? value + stepSize : value - stepSize);
        //            SetY(reverseValue ? valueY + stepSize : valueY - stepSize);
        //        }
        //        else
        //            base.OnMove(eventData);
        //        break;
        //    }
        //}

        //public override Selectable FindSelectableOnLeft()
        //{
        //    if (navigation.mode == Navigation.Mode.Automatic && axis == Axis.Horizontal)
        //        return null;
        //    return base.FindSelectableOnLeft();
        //}

        //public override Selectable FindSelectableOnRight()
        //{
        //    if (navigation.mode == Navigation.Mode.Automatic && axis == Axis.Horizontal)
        //        return null;
        //    return base.FindSelectableOnRight();
        //}

        //public override Selectable FindSelectableOnUp()
        //{
        //    if (navigation.mode == Navigation.Mode.Automatic && axis == Axis.Vertical)
        //        return null;
        //    return base.FindSelectableOnUp();
        //}

        //public override Selectable FindSelectableOnDown()
        //{
        //    if (navigation.mode == Navigation.Mode.Automatic && axis == Axis.Vertical)
        //        return null;
        //    return base.FindSelectableOnDown();
        //}

        public virtual void OnInitializePotentialDrag(PointerEventData eventData)
        {
            eventData.useDragThreshold = false;
        }

    }
}
