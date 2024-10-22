using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Silder class 사용하기 위해 추가합니다.

public class SliderTimer : MonoBehaviour {
    Slider slTimer;

    public TimerWaterRoom timer;
    public float power = 0.15f;

    void Start() {
        slTimer = GetComponent<Slider>();
    }

    void Update() {
        if (slTimer.value > 0.0f) {
            inputEventSpace();
            slTimer.value -= Time.deltaTime;
        } else {
            PlayerPrefs.SetString("SelectedItemKey", "nothing");
            PlayerData.Data_Player_Life -= 1;
            PlayerData.instance.CallResultScene(Result_State.main);
        }
    }

    public void inputEventSpace(){
        if(Input.GetKeyDown(KeyCode.Space)){
            slTimer.value += power;

            if(slTimer.value >= 10) {
                timer.TacoOff();
            }
        }
    } 
}
