using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteChangeTest : MonoBehaviour
{
    public Sprite[] digitNumbers;
    public GameObject[] padNumbers;
    public GameObject[] displays;
    private AudioSource audioSource;

    private int dpCnt = 0;
    private const string ANSWER = "8230";
    private string userAnswer = "";

    private void Start() {
        OnResetButtonClick();
        dpCnt = 0;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(pos, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            audioSource.Play();

            if (hit.collider != null)
            {
                // 엔터 버튼 또는 리셋 버튼을 누름
                if (hit.collider.name == "enter") {
                    Debug.Log("Enter 입니다.");
                    OnEnterButtonClick();

                    return;
                } else if (hit.collider.name == "reset") {
                    Debug.Log("Reset 입니다.");
                    OnResetButtonClick();

                    return;
                }


                // 숫자 버튼을 누름
                if (userAnswer.Length < 4) {
                    int index = 0;
                    for (int i = 0; i < padNumbers.Length; i++) {
                        if (hit.collider.gameObject == padNumbers[i]) {
                            index = i;
                            break;
                        }
                    }
                    SpriteRenderer sr = displays[dpCnt].GetComponent<SpriteRenderer>();
                    sr.sprite = digitNumbers[index];
                    userAnswer += index;
                    dpCnt = (dpCnt + 1) % displays.Length;

                }
            }
            print(userAnswer + "  길이 : " + userAnswer.Length);
        }
    }

    public void OnResetButtonClick() {
        userAnswer = "";
        dpCnt = 0;
        for (int i = 0; i < displays.Length; i++) {
            SpriteRenderer temp = displays[i].GetComponent<SpriteRenderer>();
            temp.sprite = digitNumbers[0];
        }
    }

    public void OnEnterButtonClick() {
        if (userAnswer.Equals(ANSWER)) {
            PlayerData.Data_Stage2_Clear = true;
            PlayerData.CurrentStage = 3;
            PuzzleSoundManager.instance.SoundPlay(true);
        } else {
            OnResetButtonClick();
            PuzzleSoundManager.instance.SoundPlay(false);
        }
    }
}
