using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LookArray {
    public GameObject[] look;
}

public class StageUIController : MonoBehaviour
{
    //public LookArray[] roomArray;

    public GameObject[] Room;

    public GameObject lrBtn;
    public GameObject backBtn;

    public GameObject optionPanel;

    private CameraTarget cameraTarget;
    private FadeInOut fadeInOut;

    public delegate void Input_Back();
    public Input_Back subClear;

    private void Start() {

        if (PlayerPrefs.HasKey("LRBtn")) {
            lrBtn.SetActive(System.Convert.ToBoolean(PlayerPrefs.GetInt("LRBtn")));
        } else {
            lrBtn.SetActive(true);
        }

        if (PlayerPrefs.HasKey("BackBtn")) {
            backBtn.SetActive(System.Convert.ToBoolean(PlayerPrefs.GetInt("BackBtn")));
        } else {
            backBtn.SetActive(false);
        }

        if (PlayerPrefs.HasKey("RoomNum")) {
            StageCtrl(PlayerPrefs.GetInt("RoomNum", 0));
        } else {
            StageCtrl(0);
        }

        cameraTarget = GetComponent<CameraTarget>();
        fadeInOut = GetComponent<FadeInOut>();

    }

    public void MainUICtrl(bool lr, bool back) {
        lrBtn.SetActive(lr);
        backBtn.SetActive(back);

        PlayerPrefs.SetInt("LRBtn", System.Convert.ToInt16(lr));
        PlayerPrefs.SetInt("BackBtn", System.Convert.ToInt16(back));
    }

    public void StageCtrl(int num) {
        for(int i = 0; i < Room.Length; i++) {
            Room[i].SetActive(false);
        }
        Room[num].SetActive(true);
    }

    public void OnLeftButtonClick() {
        //fadeInOut.FadeOutIn();
        int num = cameraTarget.LookNum;

        if(num == 0) {
            num = 3;
            cameraTarget.CameraYPlus(-45);

        } else{
            num--;
            cameraTarget.CameraYPlus(15);
        }
        cameraTarget.LookNum = num;
    }

    public void OnRightButtonClick() {
        //fadeInOut.FadeOutIn();
        int num = cameraTarget.LookNum;

        if (num == 3) {
            num = 0;
            cameraTarget.CameraYPlus(45);

        } else {
            num++;
            cameraTarget.CameraYPlus(-15);
        }

        cameraTarget.LookNum = num;
    }

    public void OnBackButtonClick() {
        fadeInOut.FadeOutIn();
        cameraTarget.CameraXPlus(-25);
        cameraTarget.BackPointX--;

        if (cameraTarget.BackPointX == 0)
        {
            MainUICtrl(true, false);
        }

        subClear();
    }

    public void OnOptionBtnClick() {
        SlotToggle.instance.ClearSelect();
        PlayerPrefs.SetString("SelectedItemKey", "nothing");
        optionPanel.SetActive(true);
    }

    public void OnCloseBtnClick() {
        optionPanel.SetActive(false);
    }

    public void OnHomeBtnClick() {
        PlayerPrefs.SetString("SelectedItemKey", "nothing");
        StartCoroutine(HomeCoroutine(0.02f));
    }

    IEnumerator HomeCoroutine(float _speed) {
        OnCloseBtnClick();
        fadeInOut.FadeOut();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Main");
    }

    public void Carrot() {
        PlayerPrefs.DeleteAll();
        print("데이터 초기화");
    }
}
