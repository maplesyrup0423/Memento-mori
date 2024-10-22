using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPuzzleMng : MonoBehaviour
{
    public Item[] nowItem;
    public Item[] answer;
    // 놓여있는지 아닌지를 판단
    public bool[] state;

    private void Start()
    {
        nowItem = new Item[3];
        state = new bool[3];

        state[0] = false;
        state[1] = false;
        state[2] = false;
    }

    public void CheckPotionAnswer()
    {
        Debug.Log("물약 정답을 검사합니다");

        bool a1 = false, a2 = false, a3 =false;

        if (state[0] && nowItem[0] == answer[0])
        {
            a1 = true;
        }
        if (state[1] && nowItem[1] == answer[1])
        {
            a2 = true;
        }
        if (state[2] && nowItem[2] == answer[2])
        {
            a3 = true;
        }

        if (a1 && a2 && a3)
        {
            StartCoroutine(CorrectPotionPuzzle());
        }
    }

    private IEnumerator CorrectPotionPuzzle()
    {
        Debug.Log("포션 퍼즐 정답입니다!");
        PuzzleSoundManager.instance.SoundPlay(true);
        PlayerData.Data_Stage4_Clear = true;
        PlayerData.CurrentStage = 5;

        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
