using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public Transform hand; // 버튼에 맞는 시계침
    public float angle = 30.0f; // 시계침이 회적하는 각도
    public float startAngle = -180.0f;

    private float nowAngle = 0.0f;

    void Start()
    {
        nowAngle = startAngle;
        hand.rotation = Quaternion.Euler(0, 0, nowAngle);
    }

    private void OnMouseUp() {
        OnClockButtonClick();
    }

    private void OnClockButtonClick() {
        nowAngle = (nowAngle - angle) % 360.0f;
        hand.rotation = Quaternion.Euler(0, 0, nowAngle);

        if (PuzzleDataManager.Data_Clock_WaterRoom) {

            if(PlayerData.CurrentStage != 4)
                PuzzleSoundManager.instance.SoundPlay(true);

            PlayerData.Data_Stage3_Clear = true;
            PlayerData.CurrentStage = 4;
        }
    }
}
