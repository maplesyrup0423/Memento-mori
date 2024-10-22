using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSceneManager : MonoBehaviour
{
    #region 싱글톤
    private static StageSceneManager _instance;
    public static StageSceneManager instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<StageSceneManager>();
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

    public GameObject manager;

    public CameraTarget camTarget;

    public StageUIController stageUI;

    public ScreenEffects effects;

    //true면 뒤져요
    [HideInInspector]
    public bool _check_lightA = true;

    private void Start() {
        manager = GameObject.FindWithTag("ScreenManager");
        stageUI = manager.GetComponent<StageUIController>();
        camTarget = manager.GetComponent<CameraTarget>();
        effects = manager.GetComponent<ScreenEffects>();
    }
}
