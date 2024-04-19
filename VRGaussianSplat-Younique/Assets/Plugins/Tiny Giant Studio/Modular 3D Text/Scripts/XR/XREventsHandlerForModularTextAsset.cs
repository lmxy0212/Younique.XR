using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace TinyGiantStudio.Text
{
    [DisallowMultipleComponent]
    public class XREventsHandlerForModularTextAsset : MonoBehaviour
    {
        XRToolkitGlobalInputControllerForModularTextAsset globalInputController;

        Button button;
        InputField inputField;


        private void Start()
        {
            globalInputController = XRToolkitGlobalInputControllerForModularTextAsset.Instance;

            button = GetComponent<Button>();
            inputField = GetComponent<InputField>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void HoverEntered(HoverEnterEventArgs hoverEnterEventArgs)
        {
            button?.SelectButton();
            
            if (inputField)
                inputField.state.State = UIState.StateEnum.hovered;
        }

        public void HoverExited(HoverExitEventArgs hoverExitEventArgs)
        {
            button?.UnselectButton();

            if (inputField)
                inputField.state.State = UIState.StateEnum.unhovered;
        }

        public void SelectEnter(SelectEnterEventArgs selectEnterEventArgs)
        {
            if (globalInputController == null)
                globalInputController = XRToolkitGlobalInputControllerForModularTextAsset.Instance;

            if (globalInputController != null)
                globalInputController.SelectNewItem(gameObject);

            button?.ButtonBeingPressed();
            button?.PressButtonVisualUpdate();


            if (inputField)
                inputField.state.State = UIState.StateEnum.pressStart;
        }
        public void SelectExit(SelectExitEventArgs selectExitEventArgs)
        {
            if (selectExitEventArgs.isCanceled)
                return;

            if (globalInputController == null)
                globalInputController = XRToolkitGlobalInputControllerForModularTextAsset.Instance;

            globalInputController?.Unselect(gameObject);

            button?.PressCompleted();

            if (inputField)
                inputField.state.State = UIState.StateEnum.pressComplete;
        }
        ///// <summary>
        ///// Scrapped it because couldn't test the Activated event with Toolkit
        ///// </summary>
        ///// <param name="activateEventArgs"></param>
        //public void ButtonActivated(ActivateEventArgs activateEventArgs)
        //{
        //    if (globalInputController == null)
        //        globalInputController = XRToolkitGlobalInputControllerForModularTextAsset.Instance;

        //    if (globalInputController != null)
        //        globalInputController.SelectNewItem(gameObject);

        //    if (button == null)
        //        button = GetComponent<Button>();

        //    if (button != null)
        //        button.PressButton();
        //}


        public void InputFieldActivated(ActivateEventArgs activateEventArgs)
        {
            if (globalInputController == null)
                globalInputController = XRToolkitGlobalInputControllerForModularTextAsset.Instance;

            if (globalInputController != null)
                globalInputController.SelectNewItem(gameObject);
        }
    }
}