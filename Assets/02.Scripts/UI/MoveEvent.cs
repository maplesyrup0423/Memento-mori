using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType
{
    Sub, Other, NextStage
}

public class MoveEvent : MonoBehaviour
{
    public MoveType moveType;
    public float camX, camY;
    public int roomN, lookN;
    public int subN;
    public GameObject[] subScreen;

    private GameObject uiManager;
    private StageUIController stageUIControl;
    private CameraTarget cameraTarget;
    private FadeInOut fadeInOut;

    private Lock_Interaction lock_Interaction;

    private int key;

    private void Start()
    {
        uiManager = GameObject.FindWithTag("ScreenManager");
        stageUIControl = uiManager.GetComponent<StageUIController>();
        cameraTarget = uiManager.GetComponent<CameraTarget>();
        fadeInOut = uiManager.GetComponent<FadeInOut>();
        lock_Interaction = GetComponent<Lock_Interaction>();

        StageSceneManager.instance.stageUI.subClear += ClearSubScreen;
    }

    public void ClearSubScreen() {
        for (int i = 0; i < subScreen.Length; i++) {
            subScreen[i].SetActive(false);
        }
    }

    private void OnMouseUp()
    {


        lock_Interaction.keyCheck();
        
        if (moveType == MoveType.Sub)
        {
            MoveToSub();
        }

        if (moveType == MoveType.Other)
        {
            MoveToOther();
        }

        if (moveType != MoveType.NextStage) {
            subScreenSet(subN);
        }

    }

    public void subScreenSet(int number) {
        for(int i = 0; i < subScreen.Length; i++) {
            subScreen[i].SetActive(false);
        }

        subScreen[number].SetActive(true);
    }

    //TODO: 막혔을 때 연출도 여기서 적당히 처리해야 할듯. 사운드라던가 텍스트라던가
    public void MoveToSub()
    {
        if (!lock_Interaction.SubLockCheck)
        {
            fadeInOut.FadeOutIn();

            cameraTarget.CameraXPlus(25);

            cameraTarget.BackPointX++;

            stageUIControl.MainUICtrl(false, true);
        }

    }

    public void MoveToOther()
    {
        if (!lock_Interaction.OtherLockCheck)
        {
            fadeInOut.FadeOutIn();

            cameraTarget.RoomNum = roomN;
            cameraTarget.LookNum = lookN;
            cameraTarget.CameraMove(camX, camY);

            cameraTarget.BackPointX = 0;
            stageUIControl.MainUICtrl(true, false);

            stageUIControl.StageCtrl(roomN);
        }

    }

    public void MoveToOther(int room, int look, float camx, float camy) {
        if (!lock_Interaction.OtherLockCheck) {
            fadeInOut.FadeOutIn();

            cameraTarget.RoomNum = room;
            cameraTarget.LookNum = look;
            cameraTarget.CameraMove(camx, camy);

            cameraTarget.BackPointX = 0;
            stageUIControl.MainUICtrl(true, false);

            stageUIControl.StageCtrl(room);
        }

    }

    public void SetToOther(float camx, float camy, int roomn, int lookn) {
        roomN = roomn;
        lookN = lookn;
        camX = camx;
        camY = camy;
    }
}
