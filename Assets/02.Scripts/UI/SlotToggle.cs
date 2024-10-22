using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotToggle : MonoBehaviour
{
    public static SlotToggle instance
    {
        get
        {
            if(_slotToggle == null)
            {
                _slotToggle = FindObjectOfType<SlotToggle>();
            }

            return _slotToggle;
        }
    }

    private static SlotToggle _slotToggle;

    public List<Image> images;

    [SerializeField]
    private Image slotImg; // 슬롯 배경 이미지(슬롯 배경 사각형 스프라이트 흰색 - 빨간색 전환 제어)
    [SerializeField]
    private Button slotBtn; // 슬롯 한칸의 버튼
    [SerializeField]
    private Image itemImg; // 위의 버튼의 이미지 컴포넌트(인벤토리 슬롯에 들어갈 스프라이트 제어)
    [SerializeField]
    private string key; // 위의 itemImg에 들은 스프라이트 이름

    private void Awake() {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴 - 중복 생성 막기
            Destroy(gameObject);
        }
    }

    public void DoSlotToggle(Image _img)
    {
        slotImg = _img;
        slotBtn = slotImg.GetComponentInParent<Button>();
        itemImg = slotBtn.GetComponent<Image>(); //슬롯 배경이미지
        key = itemImg.sprite.name;

        //SelectedItemKey 키 값이 존재하고 && 선택한 슬롯이 이미 선택된 슬롯이었다면 && 아무것도 안들은 슬롯을 눌렀다면
        if ((PlayerPrefs.HasKey("SelectedItemKey") && key.Equals(PlayerPrefs.GetString("SelectedItemKey"))) || key.Equals("UISprite"))
        {
            // Debug.Log("첫 번째 : " + key);
            ClearSelect();
            SaveDeselectItemKey();
        }
        //아무도 선택이 안 되어 있었거나 다른 슬롯이 선택되어 있으면
        else
        {
            // Debug.Log("두 번째 : " + key);
            ClearSelect();
            SetSelect();
        }
    }

    //모든 슬롯의 선택을 초기화 - 배경 흰색
    public void ClearSelect()
    {
        for (int i = 0; i < images.Count; i++)
        {
            Image _slotImg = images[i].GetComponent<Image>();
            _slotImg.color = Color.white;
        }
    }

    //선택한 슬롯을 표시 - 배경 붉은색 2) 키값 갱신
    public void SetSelect()
    {
        Image _slotImg = slotImg.GetComponent<Image>();
        _slotImg.color = new Color(142 / 255f, 15 / 255f, 15 / 255f, 255 / 255f);
        SaveSelectItemKey(key);
    }

    private void SaveSelectItemKey(string itemName)
    {
        PlayerPrefs.SetString("SelectedItemKey", itemName);
    }

    private void SaveDeselectItemKey()
    {
        PlayerPrefs.SetString("SelectedItemKey", "nothing");
    }

}
