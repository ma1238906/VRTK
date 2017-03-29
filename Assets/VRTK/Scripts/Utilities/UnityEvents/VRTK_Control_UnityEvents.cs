﻿namespace VRTK.UnityEventHelper
{
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent(typeof(VRTK_Control))]
    public class VRTK_Control_UnityEvents : MonoBehaviour
    {
        private VRTK_Control c3d;

        [System.Serializable]
        public class UnityObjectEvent : UnityEvent<object, Control3DEventArgs> { };

        /// <summary>
        /// Emits the ValueChanged class event.
        /// </summary>
        public UnityObjectEvent OnValueChanged = new UnityObjectEvent();

        private void SetControl3D()
        {
            if (c3d == null)
            {
                c3d = GetComponent<VRTK_Control>();
            }
        }

        private void OnEnable()
        {
            SetControl3D();
            if (c3d == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage("REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT", new string[] { "VRTK_Control_UnityEvents", "VRTK_Control", "the same" }));
                return;
            }

            c3d.ValueChanged += ValueChanged;
        }

        private void ValueChanged(object o, Control3DEventArgs e)
        {
            OnValueChanged.Invoke(o, e);
        }

        private void OnDisable()
        {
            if (c3d == null)
            {
                return;
            }

            c3d.ValueChanged -= ValueChanged;
        }
    }
}