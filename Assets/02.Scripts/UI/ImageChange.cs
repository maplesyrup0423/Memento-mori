using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ImageChange : MonoBehaviour
{
    [SerializeField]
    private Button myButton;

    [SerializeField]
    private Sprite down, up;

    private void Start() {
        myButton = GetComponent<Button>();
    }
    
    public void downButton() {
        myButton.image.overrideSprite = down;
    }

    public void onButton() {
        myButton.image.overrideSprite = up;
    }
}
