using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLoseGame : MonoBehaviour
{
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
