using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockItemUse1
    : MonoBehaviour
{
    private Item item;
    private Inventory inven;
    public GameObject tomitem;
    public GameObject keyitem;
    public GameObject keycover;
    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
    }
    private void OnMouseDown()
    {
        ClockItem1();
    }
    // Update is called once per frame
    public void ClockItem1()
    {
        
        string tom = "tom";
        string key = PlayerPrefs.GetString("SelectedItemKey");
        item = inven.items.Find(x => x.itemName == key);
        if (tom == key)
        {
            tomitem.SetActive(true);
            keyitem.SetActive(true);
            keycover.SetActive(false);
            inven.RemoveItem(item);
        }
        
    }
}
