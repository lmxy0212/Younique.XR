using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class XRInstantiateGrabbableObject : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
{ 

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Get grab interactable from prefab
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable objectInteractable = gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // Select object into same interactor
        interactionManager.SelectEnter(args.interactorObject, objectInteractable);

        base.OnSelectEntered(args);
    }
}