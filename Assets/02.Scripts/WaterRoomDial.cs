using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterRoomDial : MonoBehaviour
{
    public GameObject switchbox1;
    public GameObject switchbox2;
    [SerializeField]
    private Text[] numDialTxt;


    private int[] next = { 1, 1, 1 };

    private string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    // Start is called before the first frame update
    private void Start()
    {
        numDialTxt[0].text = num[0];
        numDialTxt[1].text = num[0];
        numDialTxt[2].text = num[0];

    }

    public void WaterRoomDialListner(int number)
    {

        numDialTxt[number].text = num[next[number]];

        if (next[number] >= 9)
        {
            next[number] = 0;
        }
        else
        {
            next[number]++;
        }
    }

    public void WaterRoomDialCheckButtonClick()
    {
        string result = numDialTxt[0].text + numDialTxt[1].text + numDialTxt[2].text;

        print(result);

        if (result == "801")
        {
            StartCoroutine("TrapOpen");

        }
        else
        {
            PuzzleSoundManager.instance.SoundPlay(false);
        }
    }

    IEnumerator TrapOpen() {
        switchbox1.SetActive(false);
        switchbox2.SetActive(true);
        PuzzleSoundManager.instance.SoundPlay(true);
        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.SetString("SelectedItemKey", "nothing");
        PlayerData.Data_Player_Life -= 1;
        PlayerData.instance.CallResultScene(Result_State.main);

    }
}
