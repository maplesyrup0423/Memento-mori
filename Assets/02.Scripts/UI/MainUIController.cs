using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject optionPanel;
    public GameObject resetPanel;

    private void Start() {
        optionPanel.SetActive(false);
        resetPanel.SetActive(false);
    }

    public void OnOptionBtnClick() {
        optionPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void OnResetBtnClick() {
        resetPanel.SetActive(true);
    }

    public void OnCloseBtnClick() {
        OnResetCloseBtnClick();
        optionPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void OnResetCloseBtnClick() {
        resetPanel.SetActive(false);
    }

    public void ResetDataAll() {
        PlayerPrefs.DeleteAll();
        Debug.Log("���� ������ �ʱ�ȭ");
        OnCloseBtnClick();
    }

    //���Ұ� ��ư �ΰ�
}
