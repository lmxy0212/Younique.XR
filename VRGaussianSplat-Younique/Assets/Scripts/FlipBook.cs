#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;
#endif
using UnityEngine.Formats.Alembic.Sdk;

public class FlipBook : MonoBehaviour
{
    public AlembicStreamPlayer alembicPlayer;
    private bool isAnimating = false;
    private float animationProgress = 0f; // Progress in seconds
    private readonly float animationStep = 1f; // How much to progress the animation each second
    private readonly float resetTime = 3f; // Time at which to reset the animation

    void Start()
    {

    }

    void Update()
    {
        if (isAnimating)
        {
            // Progress the animation
            animationProgress += animationStep * Time.deltaTime;

            // Clamp animation progress within the 0 to resetTime range
            animationProgress = Mathf.Clamp(animationProgress, 0f, resetTime);

            // Set current time of the Alembic animation
            alembicPlayer.CurrentTime = animationProgress;

            // If animation reaches the reset time, reset
            if (animationProgress >= resetTime)
            {
                animationProgress = 0f; // Reset animation progress
                isAnimating = false; // Optionally stop the animation
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide!" + other.transform.gameObject.name);
        // Start or resume animation when something enters the trigger
        if (other.transform.gameObject.tag == "Manual")
        {
            isAnimating = true;
            Debug.Log("BOOK!");
        }

    }

}
