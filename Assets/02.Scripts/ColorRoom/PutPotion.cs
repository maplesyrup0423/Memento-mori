using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutPotion : MonoBehaviour
{
    public PotionPuzzleMng manager;
    public int index;

    public SpriteRenderer sr;

    [SerializeField]
    private Item useItem;
    private Inventory inven;

    private void Start()
    {
        inven = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
    }

    private void OnMouseDown()
    {
        putPotion();
        manager.CheckPotionAnswer();
    }

    // 인벤토리의 포션을 설치하기
    public void putPotion()
    {
        string key = PlayerPrefs.GetString("SelectedItemKey");

        if (key.Contains("Potion") && !manager.state[index])
        {
            Debug.Log("포션입니다.");

            useItem = inven.items.Find(x => x.itemName == key);
            inven.RemoveItem(useItem);
            manager.nowItem[index] = useItem;
            sr.gameObject.SetActive(true);
            sr.sprite = useItem.itemImage;
            manager.state[index] = true;
        }
    }
}
