using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockItemUse : MonoBehaviour
{
    private Item item;
    private Inventory inven;
    public GameObject SecHand;
    public GameObject SecHitBox;
    public GameObject HourHand;
    public GameObject HourHitBox;
    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
    }
    private void OnMouseDown()
    {
        ClockItem();
    }
    // Update is called once per frame
    public void ClockItem()
    {
        
        string Skey = "SecHand";
        string Hkey = "HourHand";
        string key = PlayerPrefs.GetString("SelectedItemKey");
        item = inven.items.Find(x => x.itemName == key);
        if (Skey == key)
        {
            SecHand.SetActive(true);
            SecHitBox.SetActive(true);
            inven.RemoveItem(item);
        }
        else if (Hkey == key)
        {
            HourHand.SetActive(true);
            HourHitBox.SetActive(true);
            inven.RemoveItem(item);
        }
    }
}
