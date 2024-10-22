using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    None,SubLock, OtherLock, NextStage
}

public class Lock_Interaction : MonoBehaviour
{
    public InteractionType type;
    public string keyName;
    public Item item;

    private bool sublockcheck;
    private bool otherlockcheck;

    private Inventory inven;

    public bool SubLockCheck { get { return sublockcheck; } }

    public bool OtherLockCheck { get { return otherlockcheck; } }

    private void Start()
    {
        inven = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();

        if (type == InteractionType.SubLock)
        {
            sublockcheck = true;
        }
        else if (type == InteractionType.OtherLock)
        {
            otherlockcheck = true;
        }
    }

    //잠금푸는 용 
    public void keyCheck()
    {
        if(keyName == PlayerPrefs.GetString("SelectedItemKey", "nothing")) {
            //TODO: 열리는 연출
            if(!StageSceneManager.instance._check_lightA) {
                PlayerData.Data_Stage1_Clear = true;
                PlayerData.CurrentStage = 2;

                if (type == InteractionType.SubLock) {
                    sublockcheck = false;
                    otherlockcheck = true;
                } else if (type == InteractionType.OtherLock) {
                    otherlockcheck = false;
                    sublockcheck = true;
                }
                inven.RemoveItem(item);
            }
        }

    }
}
