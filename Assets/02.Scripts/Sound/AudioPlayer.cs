using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource audioSource;
    public string key;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    private void OnMouseDown()
    {
        if (key == "Default")
        {
            audioSource.Play();
        }
        else if (key == PlayerPrefs.GetString("SelectedItemKey", "nothing"))
        {
            audioSource.Play();
        }
    }
}
