using UnityEngine;

public class MenuController : MonoBehaviour
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

    void AnimateButtons()
    {
        lerpTime += Time.deltaTime / moveDuration;

        camBtn.transform.position = isExpanded ? 
            Vector3.Lerp(initialPos.position, camFinalPos.position, lerpTime) : 
            Vector3.Lerp(camFinalPos.position, initialPos.position, lerpTime);
        settingBtn.transform.position = isExpanded ? 
            Vector3.Lerp(initialPos.position, settingFinalPos.position, lerpTime) : 
            Vector3.Lerp(settingFinalPos.position, initialPos.position, lerpTime);
        homeBtn.transform.position = isExpanded ? 
            Vector3.Lerp(initialPos.position, homeFinalPos.position, lerpTime) : 
            Vector3.Lerp(homeFinalPos.position, initialPos.position, lerpTime);

        if (!halfwayPointReached && lerpTime >= 0.5f)
        {
            halfwayPointReached = true;
            if (!isExpanded) SetButtonsActive(false);
        }

        if (lerpTime >= 1f)
        {
            isAnimating = false;
            SetButtonsActive(isExpanded);
        }
    }

    void SetButtonsActive(bool isActive)
    {
        camBtn.SetActive(isActive);
        settingBtn.SetActive(isActive);
        homeBtn.SetActive(isActive);
    }
}
