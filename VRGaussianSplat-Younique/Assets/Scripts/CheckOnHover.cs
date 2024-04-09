using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckOnHover : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;
    private Animator animator; // Reference to the Animator component
    public bool isTouching;

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        animator = GetComponent<Animator>(); // Get the Animator component

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
        isTouching = true;
        PlayPageFlipAnimation();
    }

    private void OnHoverExited(HoverExitEventArgs arg)
    {
        Debug.Log($"{arg.interactableObject.transform.name} stopped being touched.");
        isTouching = false;
    }

    private void PlayPageFlipAnimation()
    {
        if (animator != null)
        {
            animator.Play("PageFlip", 0, 0); // Play the PageFlip animation from the start
        }
    }
}
