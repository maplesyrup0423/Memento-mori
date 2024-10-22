using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    public GameObject myCamera;

    [SerializeField]
    private int roomNum; // �� ���� ��ȣ
    [SerializeField] 
    private int lookNum; // �� ���� ��ȣ

    private float cameraX = 0f; // ī�޶� ��ġ X ��
    private float cameraY = 15f; // ī�޶� ��ġ Y ��

    //������Ʈ ��ȣ�ۿ����� ���� ȭ�� ��ȯ �� �Ѿ ȭ�� ���� üũ
    private int backPointX = 0; 


    private void Start() { //�ʱⰪ�� 0, 1

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
    //CameraMove �Լ� : �� ������ ȭ���� �ѱ� �� ī�޶���ġ�� x, y�� �޾� �̵���Ų��.
    public void CameraMove (float x, float y) {
        PlayerPrefs.SetFloat("CameraX", x);
        cameraX = x;
        PlayerPrefs.SetFloat("CameraY", y);
        cameraY = y;

        Vector3 pos = new Vector3(x, y, -10);
        myCamera.transform.position = pos;
    }

    //CameraXPlus �Լ� : ������Ʈ ��ȣ�ۿ����� ���� ȭ�� ��ȯ �� ���Ǵ� �Լ�, x 25�� �̵��Ѵ�.
    public void CameraXPlus(float x) {
        cameraX += x;
        PlayerPrefs.SetFloat("CameraX", cameraX);

        Vector3 pos = new Vector3(cameraX, cameraY, -10);
        myCamera.transform.position = pos;
    }

    //CameraYPlus �Լ� : UI ��ȣ�ۿ����� �� ���� ��ȯ���� ���� ȭ���� �ѱ� �� ���Ǵ� �Լ�, y 15�� �̵��Ѵ�
    public void CameraYPlus(float y) {
        cameraY += y;
        PlayerPrefs.SetFloat("CameraY", cameraY);

        Vector3 pos = new Vector3(cameraX, cameraY, -10);
        myCamera.transform.position = pos;
    }
}
