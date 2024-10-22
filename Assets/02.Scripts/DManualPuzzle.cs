using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DManualPuzzle : MonoBehaviour
{
    [SerializeField]
    private Text[] btnText;
    [SerializeField]
    private Text screenText;
    [SerializeField]
    private Image[] lightImage;

    private string[] btnSet1 = {"1", "3", "2", "4"};
    private string[] btnSet2 = {"4", "3", "2", "1"};
    private string[] btnSet3 = {"2", "1", "3", "4"};
    private string[] btnSet4 = {"4", "2", "3", "1"};
    private string[] btnSet5 = {"1", "3", "4", "2"};
    private int[] answer = {3, 1, 1, 3, 4};

    public int state;

    // Start is called before the first frame update
    void Start()
    {
        // 버튼 및 스크린의 텍스트 초기화
        state = 1;
        SetTextState(1);
        SetLightState(0);
    }

    public void SetButtonNumberListener(int index)
    {
        //index : 선택한 버튼의 순서 값 (ex: index == 0 -> 첫 번째 버튼)
        if (index == answer[state-1])
        {
            // 맞은 경우
            if (state == 5)
            {
                //5단계 성공 시 퍼즐 종료
                SetLightState(state);
                print("매뉴얼 퍼즐 완료입니다.");
                PuzzleSoundManager.instance.SoundPlay(true);

                PlayerData.Data_Stage6_Clear = true;
                PlayerData.CurrentStage = 7;
            } 
            else
            {
                //이전 단계일 시 다음 단계로 세팅
                SetLightState(state);
                state++;
                SetTextState(state);
            }
        }
        else
        {
            // 틀린 경우 - 처음으로 초기화
            PuzzleSoundManager.instance.SoundPlay(false);
            SetLightState(0);
            state = 1;
            SetTextState(1);
        }

    }

    void SetTextState(int s)
    {
        //단계에 따라 스크린과 버튼의 텍스트를 변경하는 메소드
        //s : 진행 단계(변수 state)를 받아오는 매개변수

        if (s == 1)
        {
            screenText.text = "3";
            btnText[0].text = btnSet1[0];
            btnText[1].text = btnSet1[1];
            btnText[2].text = btnSet1[2];
            btnText[3].text = btnSet1[3];
        }
        else if (s == 2)
        {
            screenText.text = "3";
            btnText[0].text = btnSet2[0];
            btnText[1].text = btnSet2[1];
            btnText[2].text = btnSet2[2];
            btnText[3].text = btnSet2[3];
        }
        else if (s == 3)
        {
            screenText.text = "2";
            btnText[0].text = btnSet3[0];
            btnText[1].text = btnSet3[1];
            btnText[2].text = btnSet3[2];
            btnText[3].text = btnSet3[3];
        }
        else if (s == 4)
        {
            screenText.text = "1";
            btnText[0].text = btnSet4[0];
            btnText[1].text = btnSet4[1];
            btnText[2].text = btnSet4[2];
            btnText[3].text = btnSet4[3];
        }
        else if (s == 5)
        {
            screenText.text = "4";
            btnText[0].text = btnSet5[0];
            btnText[1].text = btnSet5[1];
            btnText[2].text = btnSet5[2];
            btnText[3].text = btnSet5[3];
        }
    }

    void SetLightState(int s)
    {
        //단계에 따라 우측의 전등 상태를 변경하는 메소드
        //s : 진행 단계(변수 state)를 받아오는 매개변수
        if (s == 0)
        {
            for (int i = 0; i < lightImage.Length; i++)
            {
                lightImage[i].color = Color.black;
            }
        }
        else
        {
            for (int i = 0; i < state; i++)
            {
                lightImage[i].color = Color.green;
            }

        }

    }
}
