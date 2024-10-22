using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Result_State {
    next, main, boss2D
}

public class PlayerData : MonoBehaviour
{

    #region 싱글톤
    private static PlayerData _instance;
    public static PlayerData instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<PlayerData>();
            }
            // 싱글톤 오브젝트를 반환
            return _instance;
        }
    }

    private void Awake() {
        if (instance != this) {
            Destroy(gameObject);
        }
    }


    #endregion

    public static Result_State state = Result_State.next;

    //목숨
    public static int Data_Player_Life {
        get => PlayerPrefs.GetInt(nameof(Data_Player_Life), 3);
        set => PlayerPrefs.SetInt(nameof(Data_Player_Life), value);
    }

    //워터룸 시간
    public static int Data_WaterRomm_Time {
        get => PlayerPrefs.GetInt(nameof(Data_WaterRomm_Time), 9);
        set => PlayerPrefs.SetInt(nameof(Data_WaterRomm_Time), value);
    }

    #region 스테이지 데이터

    public static int CurrentStage {
        get => PlayerPrefs.GetInt(nameof(CurrentStage), 1);
        set => PlayerPrefs.SetInt(nameof(CurrentStage), value);
    }
    //스테이지 클리어 여부
    public static bool Data_Stage1_Clear {
        get => PlayerPrefs.GetInt(nameof(Data_Stage1_Clear), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Stage1_Clear), value ? 1 : 0);
    }

    public static bool Data_Stage2_Clear {
        get => PlayerPrefs.GetInt(nameof(Data_Stage2_Clear), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Stage2_Clear), value ? 1 : 0);
    }

    public static bool Data_Stage3_Clear {
        get => PlayerPrefs.GetInt(nameof(Data_Stage3_Clear), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Stage3_Clear), value ? 1 : 0);
    }

    public static bool Data_Stage4_Clear {
        get => PlayerPrefs.GetInt(nameof(Data_Stage4_Clear), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Stage4_Clear), value ? 1 : 0);
    }

    public static bool Data_Stage5_Clear {
        get => PlayerPrefs.GetInt(nameof(Data_Stage5_Clear), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Stage5_Clear), value ? 1 : 0);
    }

    public static bool Data_Stage6_Clear {
        get => PlayerPrefs.GetInt(nameof(Data_Stage6_Clear), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Stage6_Clear), value ? 1 : 0);
    }

    public static bool Data_Stage7_Clear {
        get => PlayerPrefs.GetInt(nameof(Data_Stage7_Clear), 0) != 0;
        set => PlayerPrefs.SetInt(nameof(Data_Stage7_Clear), value ? 1 : 0);
    }

    #endregion

    public void CallResultScene(string key, Result_State c_state) {
        if(PlayerPrefs.GetInt(key) == 1) {
            state = c_state;
            SceneManager.LoadScene("Result");
            
        } else {
            print("Result 불러오기 실패");
        }
    }

    public void CallResultScene(Result_State c_state) {
        state = c_state;
        SceneManager.LoadScene("Result");
    }

    public void ResetButton() {
        PlayerPrefs.DeleteAll();
        Debug.Log("게임 데이터 초기화");
    }


}
