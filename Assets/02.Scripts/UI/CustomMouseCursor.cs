using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomMouseCursor : MonoBehaviour
{
    //public Texture2D cursorImage;
    public bool mouseCenter = false;
    public Vector2 adjusHotspot = Vector2.zero;

    private Vector2 hotSpot;

    public void Start() {
        Cursor.lockState = CursorLockMode.Confined;

        //StartCoroutine("CustomCursor");
    }

    //IEnumerator CustomCursor() {

    //    yield return new WaitForEndOfFrame();

    //    if (mouseCenter) {
    //        hotSpot.x = cursorImage.width / 2 ;
    //        hotSpot.y = cursorImage.height / 2;
    //    } else {
    //        hotSpot = adjusHotspot;
    //    }

    //    Cursor.SetCursor(cursorImage, hotSpot, CursorMode.Auto);
    //}
}
