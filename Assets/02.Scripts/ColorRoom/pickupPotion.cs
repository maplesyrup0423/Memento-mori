using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 금고에서 놓은 포션을 다시 꺼내는 스크립트
public class pickupPotion : MonoBehaviour
{
    public PotionPuzzleMng manager;
    public int index;

    private Item item;
    private Inventory inven;
    private SpriteRenderer sr;

    private void Start()
    {
        inven = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp()
    {
        pickup();
    }

    public void pickup()
    {
        if (manager.state[index])
        {
            item = manager.nowItem[index];
            inven.AddItem(item);
            sr.sprite = null;
            sr.gameObject.SetActive(false);
            manager.nowItem[index] = null;
            manager.state[index] = false;
        }
    }

}
