using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum isclock{Hour, Min, Sec};

public class ClockCheck : MonoBehaviour
{
    public isclock _isclock;

    [HideInInspector]
    public static bool isHour, isMin, isSec;

    private void Start() {
        isHour = isMin = isSec = false;
        //TODO: 실제 게임에 붙일땐 지우기
        PuzzleDataManager.Data_Clock_WaterRoom = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        switch (_isclock) {
            case isclock.Hour:
                if (collision.name == "HourHitBox") isHour = true;
                break;
            case isclock.Min:
                if (collision.name == "MinHitBox") isMin = true;
                break;
            case isclock.Sec:
                if (collision.name == "SecHitBox") isSec = true;
                break;
        }

        if (isHour && isMin && isSec) {
            PuzzleDataManager.Data_Clock_WaterRoom = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        switch (_isclock) {
            case isclock.Hour:
                if (collision.name == "HourHitBox") isHour = false;
                break;
            case isclock.Min:
                if (collision.name == "MinHitBox") isMin = false;
                break;
            case isclock.Sec:
                if (collision.name == "SecHitBox") isSec = false;
                break;
        }
    }
}
