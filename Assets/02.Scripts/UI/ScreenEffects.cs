using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffects : MonoBehaviour
{
    public GameObject[] effects;

    private void Start() {
        for (int i = 0; i < effects.Length; i++)
            effects[i].SetActive(false);

        EffectOn();
    }

    public void EffectOn() {
        effects[StageSceneManager.instance.camTarget.RoomNum].SetActive(true);
        print("이펙트를 킵니다 : " + StageSceneManager.instance.camTarget.RoomNum);
    }

    public void EffectOn(int number) {
        effects[number].SetActive(true);
    }

    public void EffectOff(int number) {
        for (int i = 0; i < effects.Length; i++)
            effects[i].SetActive(false);
    }
}
