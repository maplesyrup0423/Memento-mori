using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item;
    private Inventory inven;

    private void Start() {
        inven = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
    }

    private void OnMouseUp() {
        pickup();
    }

    public void pickup() {
        inven.AddItem(item);
        Destroy(gameObject, 0.1f);
    }

}
