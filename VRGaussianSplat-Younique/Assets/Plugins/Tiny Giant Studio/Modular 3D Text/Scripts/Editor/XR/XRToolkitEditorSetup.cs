#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


namespace TinyGiantStudio.Text
{
    public class XRToolkitEditorSetup
    {
        /// <summary>
        /// Used by button
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myStyleButton"></param>
        public static void CreateSetupButton(Object myObject, GUIStyle myStyleButton)
        {
            if (myObject == null)
                return;
            GameObject gameObject = myObject as GameObject;
            if (gameObject == null)
                return;

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Update XR Interaction", myStyleButton, GUILayout.MaxWidth(200), GUILayout.Height(25)))
            {
                SetupToolkitForButton(myObject, gameObject);
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        public static void CreateSetupButtonForSlider(Object myObject, GUIStyle myStyleButton)
        {
            if (myObject == null)
                return;
            GameObject gameObject = myObject as GameObject;
            if (gameObject == null)
                return;

            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Update XR Interaction", myStyleButton, GUILayout.MaxWidth(200), GUILayout.Height(25)))
            {
                SetupToolkitForSlider(myObject, gameObject);
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Please make sure the collider on grabbable maches the handle graphic for XR.", EditorStyles.miniLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        static void SetupToolkitForSlider(Object myObject, GameObject gameObject)
        {
            Undo.RecordObject(gameObject, gameObject.name + " xr interaction update");

            if (gameObject.GetComponent<Slider>() == null)
                return;

            Slider slider = gameObject.GetComponent<Slider>();

            if (slider.handle)
                if (slider.handle.GetComponent<Collider>())
                    slider.handle.GetComponent<Collider>().enabled = false;


            if (slider.background)
                if (slider.background.GetComponent<Collider>())
                    slider.background.GetComponent<Collider>().enabled = false;

            GameObject grabbable = null;
            foreach (Transform child in gameObject.transform)
                if (child.gameObject.name.Contains("Grabbable"))
                    grabbable = child.gameObject;

            if (grabbable == null)
            {
                grabbable = new GameObject("Grabbable (Don't rename)", typeof(Rigidbody), typeof(BoxCollider));
                Undo.RegisterCreatedObjectUndo(grabbable, "Create grabbable");
                grabbable.transform.SetParent(gameObject.transform);

                if (slider.handle)
                    grabbable.transform.localScale = slider.handle.transform.localScale;
            }

            if (slider.handle)
                grabbable.transform.position = gameObject.GetComponent<Slider>().handle.transform.position;

            if (grabbable.GetComponent<MeshRenderer>() != null)
                grabbable.GetComponent<MeshRenderer>().enabled = false;



            if (grabbable.GetComponent<Collider>() == null)
                Undo.AddComponent(grabbable, typeof(BoxCollider));
            grabbable.GetComponent<BoxCollider>().enabled = true;
            grabbable.GetComponent<BoxCollider>().isTrigger = false;


            if (grabbable.GetComponent<Rigidbody>() == null)
                Undo.AddComponent(grabbable, typeof(Rigidbody));
            grabbable.GetComponent<Rigidbody>().useGravity = false;
            grabbable.GetComponent<Rigidbody>().isKinematic = true;


            if (grabbable.GetComponent<XRToolkitSliderHandleGrabbable>() == null)
                Undo.AddComponent(grabbable, typeof(XRToolkitSliderHandleGrabbable));
            XRToolkitSliderHandleGrabbable xRToolkitSliderHandleGrabbable = grabbable.GetComponent<XRToolkitSliderHandleGrabbable>();
            xRToolkitSliderHandleGrabbable.slider = gameObject.GetComponent<Slider>();
            xRToolkitSliderHandleGrabbable.enabled = true;


            if (grabbable.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>() == null)
                Undo.AddComponent(grabbable, typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable));

            if (grabbable.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>() == null)
                Undo.AddComponent(grabbable, typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable));
            UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable xRGrabInteractable = grabbable.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            xRGrabInteractable.throwOnDetach = false;

            if (!HoverEnterEventAlreadyContains(xRGrabInteractable.hoverEntered, xRToolkitSliderHandleGrabbable, "HoverEnter"))
                UnityEventTools.AddPersistentListener(xRGrabInteractable.hoverEntered, xRToolkitSliderHandleGrabbable.HoverEnter);

            if (!HoverExitEventAlreadyContains(xRGrabInteractable.hoverExited, xRToolkitSliderHandleGrabbable, "HoverExit"))
                UnityEventTools.AddPersistentListener(xRGrabInteractable.hoverExited, xRToolkitSliderHandleGrabbable.HoverExit);

            if (!SelectEnterEventAlreadyContains(xRGrabInteractable.selectEntered, xRToolkitSliderHandleGrabbable, "SelectEntered"))
                UnityEventTools.AddPersistentListener(xRGrabInteractable.selectEntered, xRToolkitSliderHandleGrabbable.SelectEntered);

            if (!SelectExitEventAlreadyContains(xRGrabInteractable.selectExited, xRToolkitSliderHandleGrabbable, "SelectExited"))
                UnityEventTools.AddPersistentListener(xRGrabInteractable.selectExited, xRToolkitSliderHandleGrabbable.SelectExited);

            Debug.Log("XR interaction updated for " + gameObject.name);
        }

















        static void SetupToolkitForButton(Object myObject, GameObject gameObject)
        {
            Undo.RecordObject(gameObject, gameObject.name + " xr interaction update");

            if (!gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>())
                gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();

            if (!gameObject.GetComponent<XREventsHandlerForModularTextAsset>())
                gameObject.AddComponent<XREventsHandlerForModularTextAsset>();

            UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable xRSimpleInteractable = gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
            XREventsHandlerForModularTextAsset xREventsHandlerForModularTextAsset = gameObject.GetComponent<XREventsHandlerForModularTextAsset>();


            if (!HoverEnterEventAlreadyContains(xRSimpleInteractable.hoverEntered, xREventsHandlerForModularTextAsset, "HoverEntered"))
                UnityEventTools.AddPersistentListener(xRSimpleInteractable.hoverEntered, xREventsHandlerForModularTextAsset.HoverEntered);

            if (!HoverExitEventAlreadyContains(xRSimpleInteractable.hoverExited, xREventsHandlerForModularTextAsset, "HoverExited"))
                UnityEventTools.AddPersistentListener(xRSimpleInteractable.hoverExited, xREventsHandlerForModularTextAsset.HoverExited);

            if (!SelectEnterEventAlreadyContains(xRSimpleInteractable.selectEntered, xREventsHandlerForModularTextAsset, "SelectEnter"))
                UnityEventTools.AddPersistentListener(xRSimpleInteractable.selectEntered, xREventsHandlerForModularTextAsset.SelectEnter);

            if (!SelectExitEventAlreadyContains(xRSimpleInteractable.selectExited, xREventsHandlerForModularTextAsset, "SelectExit"))
                UnityEventTools.AddPersistentListener(xRSimpleInteractable.selectExited, xREventsHandlerForModularTextAsset.SelectExit);

            Debug.Log("XR interaction updated!");
        }

        static bool HoverEnterEventAlreadyContains(HoverEnterEvent myEvent, object target, string targetMethodName)
        {
            for (int i = 0; i < myEvent.GetPersistentEventCount(); i++)
            {
                if (myEvent.GetPersistentTarget(i) == (object)target)
                {
                    if (myEvent.GetPersistentMethodName(i) == targetMethodName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool HoverExitEventAlreadyContains(HoverExitEvent myEvent, object target, string targetMethodName)
        {
            for (int i = 0; i < myEvent.GetPersistentEventCount(); i++)
            {
                if (myEvent.GetPersistentTarget(i) == (object)target)
                {
                    if (myEvent.GetPersistentMethodName(i) == targetMethodName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        static bool SelectEnterEventAlreadyContains(SelectEnterEvent myEvent, object target, string targetMethodName)
        {
            for (int i = 0; i < myEvent.GetPersistentEventCount(); i++)
            {
                if (myEvent.GetPersistentTarget(i) == (object)target)
                {
                    if (myEvent.GetPersistentMethodName(i) == targetMethodName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        static bool SelectExitEventAlreadyContains(SelectExitEvent myEvent, object target, string targetMethodName)
        {
            for (int i = 0; i < myEvent.GetPersistentEventCount(); i++)
            {
                if (myEvent.GetPersistentTarget(i) == (object)target)
                {
                    if (myEvent.GetPersistentMethodName(i) == targetMethodName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        //just unused. working perfectly
        //static bool ActivatedEventAlreadyContains(ActivateEvent myEvent, object target, string targetMethodName)
        //{
        //    for (int i = 0; i < myEvent.GetPersistentEventCount(); i++)
        //    {
        //        if (myEvent.GetPersistentTarget(i) == (object)target)
        //        {
        //            if (myEvent.GetPersistentMethodName(i) == targetMethodName)
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}
    }
}
#endif