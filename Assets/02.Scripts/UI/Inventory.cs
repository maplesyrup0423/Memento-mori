using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{    
    public List<Item> items; //슬롯에 들어온 아이템들이 있는 리스트
    public List<Item> allItems; //존재하는 모든 아이템 리스트

    [SerializeField]
    private Transform slotParent; //ItemSlot의 부모 : 스크롤뷰의 content
    [SerializeField]
    private Slot[] slots; //ItemSlot들을 가져와 넣을 배열

    //슬롯 배열에 content가 밑에 자식 ItemSlot들을 가져와 넣는다.
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    void Awake()
    {
        LoadItem();
        FreshSlot();
    }

    //저장된 키값으로 보유중인 아이템을 찾아 items 리스트 넣음
    public void LoadItem()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            string _name = allItems[i].itemName;

            Debug.Log(i + "번째 : for문 안 : " + _name);

            if (PlayerPrefs.HasKey(_name) && PlayerPrefs.GetInt(_name) == 1)
            {
                Debug.Log(i + "번째 : if문 안 : " + _name + " = " + PlayerPrefs.GetInt(_name));
                items.Add(allItems[i]);
            }
        }
    }

    //인벤토리 슬롯 갱신
    public void FreshSlot()
    {
        int i = 0;

        //ex) 아이템 3개 -> 위의 for에서 i: 0, 1, 2 / 아래의 for에서 i : 3, 4, 5, ... , slots.length

        //현재 가지고 있는 아이템 리스트의 원소 갯수만큼 아이템 넣어주기 
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }

        //아이템 없는 슬롯부터는 null 넣어주기
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    //아이템 추가 - 얻은 아이템의 키 값 변경 코드 필요
    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            SaveGetItemKey(_item.itemName);
            FreshSlot();
        }
        else
        {
            print("슬롯이 가득 차 있습니다");
        }

    }

    //아이템 삭제 - 사용한 아이템의 키 값 변경 코드 필요
    public void RemoveItem(Item _item)
    {
        if (items.Count != 0)
        {

            items.Remove(_item);
            SaveUseItemKey(_item.itemName);
            FreshSlot();
            SlotToggle.instance.ClearSelect();
        }
        else
        {
            print("슬롯에 아이템이 없습니다");
        }

    }


    //0 : 보유 X (아직 얻지 못했거나 이미 사용한 경우)
    //1 : 보유 O (현재 보유 중인 경우)

    //얻은 아이템 이름의 키값을 1로 갱신
    public void SaveGetItemKey(string itemName)
    {
        PlayerPrefs.SetInt(itemName, 1);
        Debug.Log("Get 메소드의 " + itemName + "의 키 값 : " + PlayerPrefs.GetInt(itemName));
    }
    //사용한 아이템 이름의 키값을 0으로 갱신
    public void SaveUseItemKey(string itemName)
    {
        PlayerPrefs.SetInt(itemName, 0);
        Debug.Log("Use 메소드의 " + itemName + "의 키 값 : " + PlayerPrefs.GetInt(itemName));
    }

}
