using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetDial_4 : MonoBehaviour
{
    [SerializeField]
    private Text[] dialTxt;

    private int[] next = { 1, 1, 1, 1 };

    //TIME
    //맞추면 B-2.1.1로 이동
    private string[] alpha0 =  {"A","C","T","L", "B"};
    private string[] alpha1 = { "B", "F", "I", "U", "A" };
    private string[] alpha2 = { "N", "G", "F", "S", "M" };
    private string[] alpha3 = { "I", "O", "E", "B", "N" };

    private void Start()
    {
        dialTxt[0].text = alpha0[0];
        dialTxt[1].text = alpha1[0];
        dialTxt[2].text = alpha2[0];
        dialTxt[3].text = alpha3[0];
    }

    public void AlphabetDialClickListner(int number)
    {
        switch (number)
        {
            case 0:
                dialTxt[0].text = alpha0[next[number]];
                break;
            case 1:
                dialTxt[1].text = alpha1[next[number]];
                break;
            case 2:
                dialTxt[2].text = alpha2[next[number]];
                break;
            case 3:
                dialTxt[3].text = alpha3[next[number]];
                break;
        }

        if (next[number] >= 4)
        {
            next[number] = 0;
        }
        else
        {
            next[number]++;
        }
    }

    public void DialCheckButtonClick()
    {
        string result = dialTxt[0].text + dialTxt[1].text + dialTxt[2].text + dialTxt[3].text;
        print(result);

        if (result == "TIME")
            print("B-2.1.1로 이동합니다.");
    }
}
