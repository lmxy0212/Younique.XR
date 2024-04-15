using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float volume = 1.0f;
    public float muteDuration = 3.0f;
    private float timer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;
        timer = muteDuration;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            audioSource.volume = volume;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}
