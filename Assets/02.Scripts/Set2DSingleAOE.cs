using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set2DSingleAOE : MonoBehaviour
{
    [SerializeField]
    private Vector3 startScale;
    [SerializeField]
    private Vector3 endScale;
    [SerializeField]
    private float playTime = 0.3f;
    [SerializeField]
    private AnimationCurve popupAnimCurve;

    private Transform popupTf = null;
    private float playTimer = 0.0f;
    private Coroutine runningCoroutine = null;
    private void Awake()
    {
        popupTf = GetComponent<Transform>();
        endScale = gameObject.transform.localScale;
    }

    private void OnEnable()
    {
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        playTimer = 0.0f;
        runningCoroutine = StartCoroutine(CoroutinePlayAnimation());
    }

    IEnumerator CoroutinePlayAnimation()
    {
        popupTf.localScale
            = Vector3.Lerp(startScale, endScale, popupAnimCurve.Evaluate(playTimer / playTime));


        playTimer += 0.01f;
        if (playTimer > playTime)
        {
            playTimer = 0;
        }
        yield return new WaitForFixedUpdate();

        runningCoroutine = StartCoroutine(CoroutinePlayAnimation());
    }
}
