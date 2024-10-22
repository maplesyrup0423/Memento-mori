using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToOtherSet : MonoBehaviour
{
    public string key;

    private GameObject uiManager;
    private StageUIController stageUIControl;
    private CameraTarget cameraTarget;
    private Lock_Interaction lock_Interaction;

    private void Start() {
        uiManager = GameObject.FindWithTag("ScreenManager");
        stageUIControl = uiManager.GetComponent<StageUIController>();
        cameraTarget = uiManager.GetComponent<CameraTarget>();
        lock_Interaction = GetComponent<Lock_Interaction>();
    }

    private void OnMouseUp() {
        setKeyOn(key);
    }

    public void setKeyOn(string keyName) {
        string itemName = lock_Interaction.keyName;
        if (itemName == PlayerPrefs.GetString("SelectedItemKey", "nothing")) {
            PlayerPrefs.SetInt(keyName, 1);
            cameraTarget.BackPointX = 0;
            stageUIControl.MainUICtrl(true, false);
        }
    }
}
