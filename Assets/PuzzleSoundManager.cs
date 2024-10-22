using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSoundManager : MonoBehaviour
{

    public AudioClip o_quizClip, x_quizClip, book_quizClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void SoundPlay(bool check)
    {
        if (check)
            audioSource.clip = o_quizClip;
        else
            audioSource.clip = x_quizClip;

        audioSource.Play();
    }

    public void SoundPlay()
    {
        audioSource.clip = book_quizClip;

        audioSource.Play();
    }

    #region 싱글톤
    private static PuzzleSoundManager _instance;
    public static PuzzleSoundManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PuzzleSoundManager>();
            }
            // 싱글톤 오브젝트를 반환
            return _instance;
        }
    }

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    #endregion
}
