using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjSwitch : MonoBehaviour
{
    public GameObject SetActiveF;
    public GameObject SetActiveT;

    // Start is called before the first frame update
    private void OnMouseDown()
    { 
        SetActiveT.SetActive(true);
        SetActiveF.SetActive(false);
    }
}
