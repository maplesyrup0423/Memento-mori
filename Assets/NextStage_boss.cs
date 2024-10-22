using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage_boss : MonoBehaviour
{
    private void OnMouseUp() {
            PlayerData.instance.CallResultScene(Result_State.next);
    }
}
