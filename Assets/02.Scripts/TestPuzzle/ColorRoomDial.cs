using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorRoomDial : MonoBehaviour
{
    public GameObject strongbox1;
    public GameObject strongbox2;
    [SerializeField]
    private Text[] numDialTxt;


    private int[] next = { 1,1,1,1 };

    private string[] num = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };


    private void Start()
    {
        numDialTxt[0].text = num[0];
        numDialTxt[1].text = num[0];
        numDialTxt[2].text = num[0];
        numDialTxt[3].text = num[0];

    }

    public void ColorRoomDialListner(int number)
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

    public void ColorRoomDialCheckButtonClick()
    {
        string result = numDialTxt[0].text + numDialTxt[1].text + numDialTxt[2].text + numDialTxt[3].text;

        print(result);

        if (result == "6755")
        {
            print("성공");
            PuzzleSoundManager.instance.SoundPlay(true);
            strongbox1.SetActive(false);
            strongbox2.SetActive(true);
        }
        else
        {
            PuzzleSoundManager.instance.SoundPlay(false);
        }
    }
}
