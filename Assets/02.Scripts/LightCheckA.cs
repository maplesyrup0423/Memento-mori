using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCheckA : MonoBehaviour
{
    public GameObject _monster;

    public AudioClip monsterSound;
    public AudioSource audioSource;

    void OnMouseUp()
    {
        if (StageSceneManager.instance._check_lightA && PlayerPrefs.GetString("SelectedItemKey", "nothing") == "AEntryCard") {

            audioSource.clip = monsterSound;
            audioSource.Play();

            _monster.SetActive(true);
            PlayerPrefs.SetString("SelectedItemKey", "nothing");
            PlayerData.Data_Player_Life -= 1;
            StageSceneManager.instance.stageUI.MainUICtrl(false, true);
        }
    }


}
