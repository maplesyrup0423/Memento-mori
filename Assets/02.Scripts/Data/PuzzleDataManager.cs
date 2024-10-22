using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDataManager : MonoBehaviour
{

    //퍼즐 당 하나씩 추가.
    // Key 이름 = 함수이름
    // bool keypad_check = Data_Keypad_DarRoom;
    // Data_Keypad_DarRoom = true, Data_Keypad_DarRoom = false 처럼 사용
    // PuzzleDataManager.프로퍼티명
    public static bool Data_Keypad_DarkRoom
    {
        get => PlayerPrefs.GetInt(nameof(Data_Keypad_DarkRoom), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Keypad_DarkRoom), value ? 1 : 0);
    }

    public static bool Data_Oxygen_DarkRoom {
        get => PlayerPrefs.GetInt(nameof(Data_Clock_WaterRoom), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Clock_WaterRoom), value ? 1 : 0);
    }

    public static bool Data_Clock_WaterRoom {
        get => PlayerPrefs.GetInt(nameof(Data_Clock_WaterRoom), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Clock_WaterRoom), value ? 1 : 0);
    }

    public static bool Data_Potion_ColorRoom {
        get => PlayerPrefs.GetInt(nameof(Data_Potion_ColorRoom), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Potion_ColorRoom), value ? 1 : 0);
    }
}
