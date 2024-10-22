using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public GameObject[] checkStage;

    public GameObject[] checkLife;

    public AnimationClip animClip;

    private Animator animator;

    private string nextScene;

    private void Start() {
        animator = GetComponent<Animator>();

        animator.Play(animClip.name);
        CheckResult();

        if(PlayerData.Data_Player_Life < 1) {
            PlayerPrefs.DeleteAll();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            print("삼진아웃");
        }


        switch (PlayerData.state) {
            case Result_State.main:
                nextScene = "Main";
                break;
            case Result_State.next:
                nextScene = "Basic Stage";
                break;
            case Result_State.boss2D:
                nextScene = "Boss Stage";
                if(PlayerPrefs.GetInt("Data_Stage5_Clear") == 1)
                     PlayerData.CurrentStage = 6;
                     PlayerData.Data_Stage5_Clear = true;
                break;
        }

    }

    public void CallNextScene() {
        SceneManager.LoadScene(nextScene);
    }

    public void CheckResult() {

        for (int i = 0; i < checkStage.Length; i++) {
            checkStage[i].SetActive(false);
        }

        for (int i = 0; i < 3; i++) {
            if (i == PlayerData.Data_Player_Life && PlayerData.state == Result_State.main) {
                checkLife[i].GetComponent<Image>().color = new Color(101 / 255f, 1 / 255f, 1 / 255f);
            }
            checkLife[i].SetActive(true);
        }

        for (int i = 0; i < PlayerData.Data_Player_Life; i++) {
            checkLife[i].SetActive(false);                
        }
        checkStage[0].SetActive(PlayerData.Data_Stage1_Clear);
        checkStage[1].SetActive(PlayerData.Data_Stage2_Clear);
        checkStage[2].SetActive(PlayerData.Data_Stage3_Clear);
        checkStage[3].SetActive(PlayerData.Data_Stage4_Clear);

        if (1 == PlayerPrefs.GetInt("Data_Stage5_Clear"))
        {

            checkStage[4].SetActive(true);

            if(!PlayerData.Data_Stage6_Clear)
                    PlayerData.CurrentStage = 6;
        }



        checkStage[5].SetActive(PlayerData.Data_Stage6_Clear);

        if(PlayerData.state != Result_State.main)
            checkStage[PlayerData.CurrentStage - 2].GetComponent<Image>().color = new Color(24 / 255f, 120 / 255f, 27 / 255f);
    }
}
