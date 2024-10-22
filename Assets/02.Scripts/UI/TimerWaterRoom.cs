using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerWaterRoom : MonoBehaviour
{
    public GameObject timer;

    public GameObject image;

    public GameObject mainUI, taco;
    //TODO: 시간 1
    private int start_min = 9;

    private float sec = 59;
    private int min = 0;

    public Text text_time;


    private void OnEnable() {
        timer.SetActive(true);
        print("타이머켜기");
        sec = 59;
        min = start_min;
    }
    void Start()
    {
        if (PuzzleDataManager.Data_Oxygen_DarkRoom) {
            image.SetActive(true);
            PlayerData.Data_WaterRomm_Time = 14;
        }

        min = start_min = PlayerData.Data_WaterRomm_Time;
    }

    private void Update() {
        Timer();
    }

    public void Timer() {
        sec -= Time.deltaTime;

        text_time.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);

        if((int)sec < 1) {
            if(min == 0){
                PlayerPrefs.SetString("SelectedItemKey", "nothing");
                PlayerData.Data_Player_Life -= 1;
                //TODO: 시간 2
                PlayerData.Data_WaterRomm_Time = 9;
                PlayerData.instance.CallResultScene(Result_State.main);
            } else {
                sec = 59;
                min--;
                PlayerData.Data_WaterRomm_Time = min;
            }
        }

        if (min % 2 == 0 && (int)sec == 58)
            TacoEvent();

    }

    public void TacoEvent() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        taco.SetActive(true);
        mainUI.SetActive(false);
    }

    public void TacoOff() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        taco.SetActive(false);
        mainUI.SetActive(true);
    }

}
