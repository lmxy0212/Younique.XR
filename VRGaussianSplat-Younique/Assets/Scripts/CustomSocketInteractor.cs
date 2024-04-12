using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnLogickFactory;

public class CustomSocketInteractor : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketInteractor;

    public GameObject currentSnappedObject;
    public CustomFbxExporter saveController;

    void Awake()
    {
        // Ensure there is a socket interactor assigned.
        if (socketInteractor == null)
        {
            socketInteractor = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
        }

        // Register event listeners
        socketInteractor.selectEntered.AddListener(OnSelectEntered);
        socketInteractor.selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Record the GameObject that is now snapped into the socket
        currentSnappedObject = args.interactableObject.transform.gameObject;
        saveController.objectToExport = currentSnappedObject;
        Debug.Log("GameObject Snapped: " + currentSnappedObject.name);
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // Clear the reference when the GameObject is unsnapped
        Debug.Log("GameObject Unsnapped: " + currentSnappedObject.name);
        currentSnappedObject = null;
        saveController.objectToExport = currentSnappedObject;
    }

    public GameObject GetCurrentSnappedObject()
    {
        return currentSnappedObject;
    }
}
