using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSqure : MonoBehaviour {

    [SerializeField]
    private Vector3 startScale;
    [SerializeField]
    private Vector3 endScale = new Vector3(1, 1, 0);
    [SerializeField]
    private float playTime = 0.3f;
    [SerializeField]
    private AnimationCurve popupAnimCurve;

    private Transform popupTf = null;
    private float playTimer = 0.0f;
    private Coroutine runningCoroutine = null;
    private void Awake() {
        popupTf = GetComponent<Transform>();
    }

    private void OnEnable() {
        PlayAnimation();
    }

    private void PlayAnimation() {
        playTimer = 0.0f;
        runningCoroutine = StartCoroutine(CoroutinePlayAnimation());
    }

    IEnumerator CoroutinePlayAnimation() {
        popupTf.localScale
            = Vector3.Lerp(startScale, endScale, popupAnimCurve.Evaluate(playTimer / playTime));


        playTimer += 0.01f;
        if (playTimer > playTime) {
            yield return new WaitForSeconds(1.5f);

            PlayerData.instance.CallResultScene(Result_State.main);
            yield break;
        }
        yield return new WaitForFixedUpdate();

        runningCoroutine = StartCoroutine(CoroutinePlayAnimation());
    }
}