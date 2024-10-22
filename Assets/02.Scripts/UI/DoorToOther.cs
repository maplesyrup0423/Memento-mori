using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToOther : MonoBehaviour
{
    public string key;

    public float camX, camY;
    public int roomN, lookN;

    private MoveEvent moveEvent;

    private GameObject uiManager;
    private StageUIController stageUIControl;
    private CameraTarget cameraTarget;

    private void Start() {
        moveEvent = GetComponent<MoveEvent>();
        uiManager = GameObject.FindWithTag("ScreenManager");
        stageUIControl = uiManager.GetComponent<StageUIController>();
        cameraTarget = uiManager.GetComponent<CameraTarget>();

        if (!PlayerPrefs.HasKey(key)) {
            PlayerPrefs.SetInt(key, 0);
        } 
    }

    private void OnMouseUp() {
        toOther(key);
    }

    public void toOther(string keyName) {
        if (PlayerPrefs.GetInt(keyName, 0) == 1) {
            moveEvent.SetToOther(camX, camY, roomN, lookN);
            moveEvent.MoveToOther();
            cameraTarget.BackPointX = 0;
            stageUIControl.MainUICtrl(true, false);
        } 
    }
}
