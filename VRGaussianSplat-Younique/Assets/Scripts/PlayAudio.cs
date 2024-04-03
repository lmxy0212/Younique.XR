using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1.0f;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}
