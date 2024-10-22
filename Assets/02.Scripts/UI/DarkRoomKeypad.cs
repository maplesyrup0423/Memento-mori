using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoomKeypad : MonoBehaviour
{
    public SpriteChangeTest key;

    // Start is called before the first frame update
    void OnMouseUp()
    {
        key.OnResetButtonClick();
    }

}
