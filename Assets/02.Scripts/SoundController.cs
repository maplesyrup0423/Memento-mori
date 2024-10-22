using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip stageClip;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audioSource.loop = true;
        audioSource.clip = stageClip;
        audioSource.Play();
    }

    private void OnDisable()
    {
        audioSource.Stop();
    }
}
