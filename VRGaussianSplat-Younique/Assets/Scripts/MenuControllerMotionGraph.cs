using UnityEngine;
public class MenuControllerMotionGraph : MonoBehaviour
{
    public GameObject camBtn;
    public GameObject settingBtn;
    public GameObject homeBtn;

    public Transform initialPos;
    public Transform camFinalPos;
    public Transform settingFinalPos;
    public Transform homeFinalPos;

    public float moveDuration = 1f;
    public bool toggleMenuBtns;
    private float lerpTime;

    private bool isExpanded;
    private bool isAnimating;
    private bool halfwayPointReached;

    void Start()
    {
        SetButtonsActive(false);
        SetBoxColliderState(camBtn, false); // Initialize collider state to false
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || toggleMenuBtns)
        {
            ToggleExpandCollapse();
            toggleMenuBtns = false;
        }

        if (isAnimating)
        {
            AnimateButtons();
        }
    }

    void ToggleExpandCollapse()
    {
        isExpanded = !isExpanded;
        isAnimating = true;
        halfwayPointReached = false;
        lerpTime = 0;
        if (isExpanded) SetButtonsActive(true);
    }

    float DampingBounce(float t)
    {
        float scale = 1.0f - Mathf.Exp(-4.0f * t);
        return scale * Mathf.Cos(0.8f * t);
        // return scale;
    }

    void AnimateButtons()
    {
        lerpTime += Time.deltaTime / moveDuration;
        float easedTime = DampingBounce(lerpTime);

        camBtn.transform.position = isExpanded ?
            Vector3.Lerp(initialPos.position, camFinalPos.position, Mathf.Clamp01(easedTime)) :
            Vector3.Lerp(camFinalPos.position, initialPos.position, Mathf.Clamp01(easedTime));
        settingBtn.transform.position = isExpanded ?
            Vector3.Lerp(initialPos.position, settingFinalPos.position, Mathf.Clamp01(easedTime)) :
            Vector3.Lerp(settingFinalPos.position, initialPos.position, Mathf.Clamp01(easedTime));
        homeBtn.transform.position = isExpanded ?
            Vector3.Lerp(initialPos.position, homeFinalPos.position, Mathf.Clamp01(easedTime)) :
            Vector3.Lerp(homeFinalPos.position, initialPos.position, Mathf.Clamp01(easedTime));


        if (!halfwayPointReached && lerpTime >= 0.5f)
        {
            halfwayPointReached = true;
            if (!isExpanded) SetButtonsActive(false);
        }

        if (lerpTime >= 1f)
        {
            isAnimating = false;
            SetButtonsActive(isExpanded);
            SetBoxColliderState(camBtn, isExpanded);  // Enable/Disable BoxCollider based on expansion state
        }
    }

    void SetButtonsActive(bool isActive)
    {
        camBtn.SetActive(isActive);
        settingBtn.SetActive(isActive);
        homeBtn.SetActive(isActive);
    }

    void SetBoxColliderState(GameObject button, bool state)
    {
        BoxCollider collider = button.GetComponent<BoxCollider>();
        if (collider != null)
        {
            collider.enabled = state;
        }
    }
}
