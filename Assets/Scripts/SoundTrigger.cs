using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Add the audio clip to the AudioSource
        audioSource.clip = soundClip;
        print("Played");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Play the audio clip
            audioSource.Play();

            print("I was music");
          //  throw new System.Exception();
        }
    }
}
