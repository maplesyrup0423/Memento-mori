using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip effectClip_AppearBoss;
    public AudioClip effectClip_DieBoss;
    public AudioClip effectClip_DiePlayer;
    public AudioClip effectClip_DamageBoss;
    public AudioClip effectClip_DamagePlayer;

    private void Awake()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayAppearBoss()
    {
        audioSource.clip = effectClip_AppearBoss;
        audioSource.Play();
    }

    public void PlayDiePlayer()
    {
        audioSource.clip = effectClip_DiePlayer;
        audioSource.Play();
    }

    public void PlayDieBoss()
    {
        audioSource.clip = effectClip_DieBoss;
        audioSource.Play();
    }

    public void PlayDamageOnBoss()
    {
        audioSource.clip = effectClip_DamageBoss;
        audioSource.Play();
    }

    public void PlayDamageOnPlayer()
    {
        audioSource.clip = effectClip_DamagePlayer;
        audioSource.Play();
    }


}
