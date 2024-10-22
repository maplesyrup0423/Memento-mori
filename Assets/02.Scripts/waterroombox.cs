using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterroombox : MonoBehaviour
{
    private Item item;
    private Inventory inven;
    public GameObject box;
    public GameObject box_open;
    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
    }

    private void OnMouseDown()
    {
        KeyItem();
    }
    public void KeyItem()
    {

        string keyname = "key";
        string key = PlayerPrefs.GetString("SelectedItemKey");
        item = inven.items.Find(x => x.itemName == key);
        if (keyname == key)
        {
            box_open.SetActive(true);
            box.SetActive(false);
            inven.RemoveItem(item);
        }

    }

}
