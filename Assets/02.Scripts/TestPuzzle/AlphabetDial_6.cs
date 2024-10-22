using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetDial_6 : MonoBehaviour
{
    [SerializeField]
    private Text[] alphabetDialTxt;


    private int[] next = { 1,1,1,1,1,1 };

    private string[] alphat = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };


    private void Start()
    {
        alphabetDialTxt[0].text = alphat[0];
        alphabetDialTxt[1].text = alphat[0];
        alphabetDialTxt[2].text = alphat[0];
        alphabetDialTxt[3].text = alphat[0];
        alphabetDialTxt[4].text = alphat[0];
        alphabetDialTxt[5].text = alphat[0];
    }

    public void AlphabetDialClickListner_6(int number)
    {

         alphabetDialTxt[number].text = alphat[next[number]];

         if (next[number] >= 24)
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
        string result = alphabetDialTxt[0].text + alphabetDialTxt[1].text + alphabetDialTxt[2].text + alphabetDialTxt[3].text + alphabetDialTxt[4].text
            + alphabetDialTxt[5].text;

        print(result);

        if (result == "BEAKER")
            print("¼º°ø");
    }
}
