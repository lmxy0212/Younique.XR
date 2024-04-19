using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.XR.Interaction.Toolkit;



namespace TinyGiantStudio.Text
{
    public class XRToolkitSliderHandleGrabbable : MonoBehaviour
    {
        public Slider slider;

        private void Awake()
        {
            this.enabled = false;
        }

        void Update()
        {
            if (!Interactable())
                return;

            Vector3 localPosition = slider.transform.InverseTransformPoint(transform.localPosition);

            //Remove Y Z position from handle
            localPosition = new Vector3(localPosition.x, 0, 0);

            float size = slider.backgroundSize;
            localPosition.x = Mathf.Clamp(localPosition.x, -size / 2, size / 2);

            slider.handle.transform.localPosition = localPosition;

            slider.GetCurrentValueFromHandle();
            slider.ValueChanged();
        }

        bool Interactable()
        {
            if(slider)
                if(slider.interactable)
                    return true;

            return false;
        }

        void OnDisable() //incase object becomes disabled
        {
            this.enabled = false;
        }

        public void HoverEnter(HoverEnterEventArgs e)
        {
            if (!Interactable())
                return;

            slider.SelectedVisual();
        }

        public void HoverExit(HoverExitEventArgs e)
        {
            if (!Interactable())
                return;

            if (!this.enabled) //enabled if it is clicked
            {
                slider.UnSelectedVisual();
            }
        }

        public void SelectEntered(SelectEnterEventArgs selectEnterEventArgs)
        {
            if (!Interactable())
                return;

            slider.ClickedVisual();
            this.enabled = true;
        }
        public void SelectExited(SelectExitEventArgs selectExitEventArgs)
        {
            if (!Interactable())
                return;

            transform.position = slider.handle.transform.position;
            slider.UnSelectedVisual();
            this.enabled = false;
        }
    }
}