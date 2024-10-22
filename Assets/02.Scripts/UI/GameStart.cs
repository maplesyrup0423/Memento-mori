using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private FadeInOut fadeInOut;

    public string nextStage;

    public string bossStage;

    private void Start() {
        fadeInOut = GameObject.FindWithTag("ScreenManager").GetComponent<FadeInOut>();
    }

    private void OnMouseUp() {
        print("클릭");
        StartCoroutine(GameStartCoroutine(0.02f));   
    }

    IEnumerator GameStartCoroutine(float _speed) {
        fadeInOut.FadeOut();
        yield return new WaitForSeconds(1.0f);

        print(PlayerPrefs.GetInt("CurrentStage"));

        if (PlayerPrefs.GetInt("CurrentStage", 1) == 5)
            SceneManager.LoadScene(bossStage);
        else
            SceneManager.LoadScene(nextStage);
    }
}
