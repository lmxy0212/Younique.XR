using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections; // Needed for Coroutine

public class CheckOnGrab : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    public bool isGrabbed;
    public bool showInfo = true;
    public float showInfoDuration = 5.0f;
    public GameObject tooltip; // Make sure this is assigned in the Inspector

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        if (tooltip != null)
        {
            tooltip.SetActive(false); // Ensure the tooltip is initially hidden
        }
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs arg)
    {
        Debug.Log($"{arg.interactableObject.transform.name} was grabbed.");
        isGrabbed = true;

        // Show tooltip on first grab
        if (showInfo && tooltip != null)
        {
            StartCoroutine(ShowTooltip());
        }
    }

    private IEnumerator ShowTooltip()
    {
        tooltip.SetActive(true);
        yield return new WaitForSeconds(showInfoDuration);
        tooltip.SetActive(false);
        showInfo = false; // Ensure tooltip is only shown on the first grab
    }

    private void OnRelease(SelectExitEventArgs arg)
    {
        Debug.Log($"{arg.interactableObject.transform.name} was released.");
        isGrabbed = false;
    }
}
