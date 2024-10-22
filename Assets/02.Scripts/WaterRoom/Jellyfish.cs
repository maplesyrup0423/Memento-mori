using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown() {
        StartCoroutine("CoroutinePlayAnimation");
    }

    IEnumerator CoroutinePlayAnimation() {
        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.SetString("SelectedItemKey", "nothing");
        PlayerData.Data_Player_Life -= 1;
        PlayerData.instance.CallResultScene(Result_State.main);

    }
}
