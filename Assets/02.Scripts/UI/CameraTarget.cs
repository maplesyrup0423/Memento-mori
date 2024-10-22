using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    public GameObject myCamera;

    [SerializeField]
    private int roomNum; // 방 고유 번호
    [SerializeField] 
    private int lookNum; // 방 시점 번호

    private float cameraX = 0f; // 카메라 위치 X 값
    private float cameraY = 15f; // 카메라 위치 Y 값

    //오브젝트 상호작용으로 인한 화면 전환 시 넘어간 화면 개수 체크
    private int backPointX = 0; 


    private void Start() { //초기값은 0, 1

        if (PlayerPrefs.HasKey("RoomNum")) {
            roomNum = PlayerPrefs.GetInt("RoomNum",0);
        } else {
            roomNum = 0;
        }

        if (PlayerPrefs.HasKey("LookNum")) {
            lookNum = PlayerPrefs.GetInt("LookNum", 1);
        } else {
            lookNum = 1;
        }

        if (PlayerPrefs.HasKey("CameraX")) {
            cameraX = PlayerPrefs.GetFloat("CameraX", 0);
        } else {
            cameraX = 0f;
        }

        if (PlayerPrefs.HasKey("CameraY")) {
            cameraY = PlayerPrefs.GetFloat("CameraY", 15);
        }else {
            cameraY = -15f;
        }

        if (PlayerPrefs.HasKey("BackPointX"))
        {
            backPointX = PlayerPrefs.GetInt("BackPointX", 0);
        }
        else{
            backPointX = 0;
        }

        CameraMove(cameraX, cameraY);
    }

    public int RoomNum { 
        get { return roomNum; } 
        set {
            roomNum = value;
            PlayerPrefs.SetInt("RoomNum", roomNum);
        } 
    }

    public int LookNum {
        get { return lookNum; }
        set {
            lookNum = value;
            PlayerPrefs.SetInt("LookNum", lookNum);
        }
    }

    public int BackPointX {
        get { return backPointX; }
        set {
            backPointX = value;
            PlayerPrefs.SetInt("BackPointX", backPointX);
        }
    }
    //CameraMove 함수 : 방 단위로 화면을 넘길 때 카메라위치를 x, y로 받아 이동시킨다.
    public void CameraMove (float x, float y) {
        PlayerPrefs.SetFloat("CameraX", x);
        cameraX = x;
        PlayerPrefs.SetFloat("CameraY", y);
        cameraY = y;

        Vector3 pos = new Vector3(x, y, -10);
        myCamera.transform.position = pos;
    }

    //CameraXPlus 함수 : 오브젝트 상호작용으로 인한 화면 전환 시 사용되는 함수, x 25씩 이동한다.
    public void CameraXPlus(float x) {
        cameraX += x;
        PlayerPrefs.SetFloat("CameraX", cameraX);

        Vector3 pos = new Vector3(cameraX, cameraY, -10);
        myCamera.transform.position = pos;
    }

    //CameraYPlus 함수 : UI 상호작용으로 방 시점 전환으로 인한 화면을 넘길 때 사용되는 함수, y 15씩 이동한다
    public void CameraYPlus(float y) {
        cameraY += y;
        PlayerPrefs.SetFloat("CameraY", cameraY);

        Vector3 pos = new Vector3(cameraX, cameraY, -10);
        myCamera.transform.position = pos;
    }
}
