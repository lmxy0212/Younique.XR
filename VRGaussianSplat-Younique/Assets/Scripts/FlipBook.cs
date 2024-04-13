#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class FlipBook : MonoBehaviour
{
    public AlembicStreamPlayer alembicPlayer;
    public bool nextPage = true;
    private bool isAnimating = false;
    private float animationStartTime;
    private float animationProgress = 0f;
    private readonly float animationStep = 1f;
    private readonly float resetTime = 3f;

    void Update()
    {
        if (isAnimating)
        {
            float elapsedTime = Time.time - animationStartTime;
            if (elapsedTime < animationStep)
            {
                float newTime = nextPage ? animationProgress + elapsedTime : animationProgress - elapsedTime;
                alembicPlayer.CurrentTime = Mathf.Clamp(newTime, 0f, resetTime);
            }
            else
            {
                animationProgress += nextPage ? animationStep : -animationStep;
                animationProgress = Mathf.Clamp(animationProgress, 0f, resetTime);
                isAnimating = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide! " + other.transform.gameObject.name);
        if ((other.transform.gameObject.tag == "Manual-forward") && !isAnimating)
        {
            nextPage = true;
            animationStartTime = Time.time;
            isAnimating = true;
            Debug.Log("BOOK! Direction: " + (nextPage ? "Forward" : "Backward"));
        }
        if ((other.transform.gameObject.tag == "Manual-backward") && !isAnimating)
        {
            nextPage = false;
            animationStartTime = Time.time;
            isAnimating = true;
            Debug.Log("BOOK! Direction: " + (nextPage ? "Forward" : "Backward"));
        }
    }
}
