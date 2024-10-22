using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    [Header("스테이지 키 이름")]
    public string key;

    public Result_State state;

    private MoveEvent moveEvent;

    private void Start() {
        moveEvent = gameObject.GetComponent<MoveEvent>(); 
    }

    private void OnMouseUp() {
            PlayerData.instance.CallResultScene(key, state);

        if (PlayerPrefs.GetInt(key) == 1) {
            moveEvent.MoveToOther();
            StageSceneManager.instance.effects.EffectOn();
        }

    }
}
