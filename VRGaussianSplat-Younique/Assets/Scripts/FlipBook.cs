#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class FlipBook : MonoBehaviour
{
    public AlembicStreamPlayer alembicPlayer;
    public bool nextPage = true; // Controls the direction of the flip
    private bool isAnimating = false;
    private float animationStartTime; 
    private float animationProgress = 0f; // Progress in seconds, initial value might need to be adjusted based on your Alembic setup
    private readonly float animationStep = 1f; // Duration of one page flip
    private readonly float resetTime = 3f; // Total duration of the Alembic animation

    void Update()
    {
        if (isAnimating)
        {
            float elapsedTime = Time.time - animationStartTime;
            if (elapsedTime < animationStep)
            {
                // Calculate new animation time based on direction
                float newTime = nextPage ? animationProgress + elapsedTime : animationProgress - elapsedTime;
                alembicPlayer.CurrentTime = Mathf.Clamp(newTime, 0f, resetTime);
            }
            else
            {
                // Complete the animation step and prepare for the next trigger
                animationProgress += nextPage ? animationStep : -animationStep;
                animationProgress = Mathf.Clamp(animationProgress, 0f, resetTime);
                isAnimating = false;

                // Optionally reset animation progress if it reaches the boundaries
                if (animationProgress <= 0f || animationProgress >= resetTime)
                {
                    // Add logic here if you want to loop or reset in a specific way
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide! " + other.transform.gameObject.name);
        // Ensure animation only starts if not currently animating
        if ((other.transform.gameObject.tag == "Manual-forward") && !isAnimating)
        {
            nextPage = true;
            animationStartTime = Time.time; // Record the start time
            isAnimating = true; // Start updating the animation in Update
            Debug.Log("BOOK! Direction: " + (nextPage ? "Forward" : "Backward"));
        }
        if ((other.transform.gameObject.tag == "Manual-backward") && !isAnimating)
        {
            nextPage = false;
            animationStartTime = Time.time; // Record the start time
            isAnimating = true; // Start updating the animation in Update
            Debug.Log("BOOK! Direction: " + (nextPage ? "Forward" : "Backward"));
        }
    }
}
