using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLightA : MonoBehaviour
{
    public Sprite switchOn;
    public Sprite switchOff;
   // public SpriteRenderer window;
    public GameObject windowon;
    public GameObject windowoff;
    bool state = true;
    SpriteRenderer switchSprite;

    private void Start()
    {
        switchSprite = gameObject.GetComponent<SpriteRenderer>();
        StageSceneManager.instance._check_lightA = true;
    }

    private void OnMouseDown()
    {
        if(state) //전등이 켜진(On) 상태라면
        {
            // 전등을 끈다(Off).
            state = false;
            switchSprite.sprite = switchOff;
            //window.color = new Color(32 / 255f, 28 / 255f, 28 / 255f);
            windowon.SetActive(false);
            windowoff.SetActive(true);

            StageSceneManager.instance._check_lightA = false;

        }
        else //전등이 꺼진(Off) 상태라면
        {
            // 전등을 켠다(On).
            state = true;
            switchSprite.sprite = switchOn;
            //window.color = new Color(1f, 1f ,1f);
            windowon.SetActive(true);
            windowoff.SetActive(false);

            StageSceneManager.instance._check_lightA = true;
        }
    }
}
