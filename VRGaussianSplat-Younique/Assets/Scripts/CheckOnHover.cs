using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckOnHover : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();

        interactable.hoverEntered.AddListener(OnHoverEntered);
        interactable.hoverExited.AddListener(OnHoverExited);
    }

    private void OnDestroy()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEntered);
        interactable.hoverExited.RemoveListener(OnHoverExited);
    }

    private void OnHoverEntered(HoverEnterEventArgs arg)
    {
        Debug.Log($"{arg.interactableObject.transform.name} is being touched.");

    }

    private void OnHoverExited(HoverExitEventArgs arg)
    {
        Debug.Log($"{arg.interactableObject.transform.name} stopped being touched.");
    }
}
