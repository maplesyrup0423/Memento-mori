using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{    
    public List<Item> items; //���Կ� ���� �����۵��� �ִ� ����Ʈ
    public List<Item> allItems; //�����ϴ� ��� ������ ����Ʈ

    [SerializeField]
    private Transform slotParent; //ItemSlot�� �θ� : ��ũ�Ѻ��� content
    [SerializeField]
    private Slot[] slots; //ItemSlot���� ������ ���� �迭

    //���� �迭�� content�� �ؿ� �ڽ� ItemSlot���� ������ �ִ´�.
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    void Awake()
    {
        LoadItem();
        FreshSlot();
    }

    //����� Ű������ �������� �������� ã�� items ����Ʈ ����
    public void LoadItem()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            string _name = allItems[i].itemName;

            Debug.Log(i + "��° : for�� �� : " + _name);

            if (PlayerPrefs.HasKey(_name) && PlayerPrefs.GetInt(_name) == 1)
            {
                Debug.Log(i + "��° : if�� �� : " + _name + " = " + PlayerPrefs.GetInt(_name));
                items.Add(allItems[i]);
            }
        }
    }

    //�κ��丮 ���� ����
    public void FreshSlot()
    {
        int i = 0;

        //ex) ������ 3�� -> ���� for���� i: 0, 1, 2 / �Ʒ��� for���� i : 3, 4, 5, ... , slots.length

        //���� ������ �ִ� ������ ����Ʈ�� ���� ������ŭ ������ �־��ֱ� 
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }

        //������ ���� ���Ժ��ʹ� null �־��ֱ�
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    //������ �߰� - ���� �������� Ű �� ���� �ڵ� �ʿ�
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
            print("������ ���� �� �ֽ��ϴ�");
        }

    }

    //������ ���� - ����� �������� Ű �� ���� �ڵ� �ʿ�
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
            print("���Կ� �������� �����ϴ�");
        }

    }


    //0 : ���� X (���� ���� ���߰ų� �̹� ����� ���)
    //1 : ���� O (���� ���� ���� ���)

    //���� ������ �̸��� Ű���� 1�� ����
    public void SaveGetItemKey(string itemName)
    {
        PlayerPrefs.SetInt(itemName, 1);
        Debug.Log("Get �޼ҵ��� " + itemName + "�� Ű �� : " + PlayerPrefs.GetInt(itemName));
    }
    //����� ������ �̸��� Ű���� 0���� ����
    public void SaveUseItemKey(string itemName)
    {
        PlayerPrefs.SetInt(itemName, 0);
        Debug.Log("Use �޼ҵ��� " + itemName + "�� Ű �� : " + PlayerPrefs.GetInt(itemName));
    }

}
