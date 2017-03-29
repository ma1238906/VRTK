﻿namespace VRTK.UnityEventHelper
{
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent(typeof(VRTK_InteractableObject))]
    public class VRTK_InteractableObject_UnityEvents : MonoBehaviour
    {
        private VRTK_InteractableObject io;

        [System.Serializable]
        public class UnityObjectEvent : UnityEvent<object, InteractableObjectEventArgs> { };

        /// <summary>
        /// Emits the InteractableObjectTouched class event.
        /// </summary>
        public UnityObjectEvent OnTouch = new UnityObjectEvent();
        /// <summary>
        /// Emits the InteractableObjectUntouched class event.
        /// </summary>
        public UnityObjectEvent OnUntouch = new UnityObjectEvent();
        /// <summary>
        /// Emits the InteractableObjectGrabbed class event.
        /// </summary>
        public UnityObjectEvent OnGrab = new UnityObjectEvent();
        /// <summary>
        /// Emits the InteractableObjectUngrabbed class event.
        /// </summary>
        public UnityObjectEvent OnUngrab = new UnityObjectEvent();
        /// <summary>
        /// Emits the InteractableObjectUsed class event.
        /// </summary>
        public UnityObjectEvent OnUse = new UnityObjectEvent();
        /// <summary>
        /// Emits the InteractableObjectUnused class event.
        /// </summary>
        public UnityObjectEvent OnUnuse = new UnityObjectEvent();
        /// <summary>
        /// Emits the InteractableObjectEnteredSnapDropZone class event.
        /// </summary>
        public UnityObjectEvent OnEnterSnapDropZone = new UnityObjectEvent();
        /// <summary>
        /// Emits the InteractableObjectExitedSnapDropZone class event.
        /// </summary>
        public UnityObjectEvent OnExitSnapDropZone = new UnityObjectEvent();
        /// <summary>
        /// Emits the InteractableObjectSnappedToDropZone class event.
        /// </summary>
        public UnityObjectEvent OnSnapToDropZone = new UnityObjectEvent();
        /// <summary>
        /// Emits the InteractableObjectUnsnappedFromDropZone class event.
        /// </summary>
        public UnityObjectEvent OnUnsnapFromDropZone = new UnityObjectEvent();

        private void SetInteractableObject()
        {
            if (io == null)
            {
                io = GetComponent<VRTK_InteractableObject>();
            }
        }

        private void OnEnable()
        {
            SetInteractableObject();
            if (io == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage("REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT", new string[] { "VRTK_InteractableObject_UnityEvents", "VRTK_InteractableObject", "the same" }));
                return;
            }

            io.InteractableObjectTouched += Touch;
            io.InteractableObjectUntouched += UnTouch;
            io.InteractableObjectGrabbed += Grab;
            io.InteractableObjectUngrabbed += UnGrab;
            io.InteractableObjectUsed += Use;
            io.InteractableObjectUnused += Unuse;
            io.InteractableObjectEnteredSnapDropZone += EnterSnapDropZone;
            io.InteractableObjectExitedSnapDropZone += ExitSnapDropZone;
            io.InteractableObjectSnappedToDropZone += SnapToDropZone;
            io.InteractableObjectUnsnappedFromDropZone += UnsnapFromDropZone;
        }

        private void Touch(object o, InteractableObjectEventArgs e)
        {
            OnTouch.Invoke(o, e);
        }

        private void UnTouch(object o, InteractableObjectEventArgs e)
        {
            OnUntouch.Invoke(o, e);
        }

        private void Grab(object o, InteractableObjectEventArgs e)
        {
            OnGrab.Invoke(o, e);
        }

        private void UnGrab(object o, InteractableObjectEventArgs e)
        {
            OnUngrab.Invoke(o, e);
        }

        private void Use(object o, InteractableObjectEventArgs e)
        {
            OnUse.Invoke(o, e);
        }

        private void Unuse(object o, InteractableObjectEventArgs e)
        {
            OnUnuse.Invoke(o, e);
        }

        private void EnterSnapDropZone(object o, InteractableObjectEventArgs e)
        {
            OnEnterSnapDropZone.Invoke(o, e);
        }

        private void ExitSnapDropZone(object o, InteractableObjectEventArgs e)
        {
            OnExitSnapDropZone.Invoke(o, e);
        }

        private void SnapToDropZone(object o, InteractableObjectEventArgs e)
        {
            OnSnapToDropZone.Invoke(o, e);
        }

        private void UnsnapFromDropZone(object o, InteractableObjectEventArgs e)
        {
            OnUnsnapFromDropZone.Invoke(o, e);
        }

        private void OnDisable()
        {
            if (io == null)
            {
                return;
            }

            io.InteractableObjectTouched -= Touch;
            io.InteractableObjectUntouched -= UnTouch;
            io.InteractableObjectGrabbed -= Grab;
            io.InteractableObjectUngrabbed -= UnGrab;
            io.InteractableObjectUsed -= Use;
            io.InteractableObjectUnused -= Unuse;
            io.InteractableObjectEnteredSnapDropZone -= EnterSnapDropZone;
            io.InteractableObjectExitedSnapDropZone -= ExitSnapDropZone;
            io.InteractableObjectSnappedToDropZone -= SnapToDropZone;
            io.InteractableObjectUnsnappedFromDropZone -= UnsnapFromDropZone;
        }
    }
}