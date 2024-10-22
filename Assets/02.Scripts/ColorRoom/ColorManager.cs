using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public PickupPotions pickupPotions;
    public SpriteRenderer rgbLight;
    public SpriteRenderer potion;
    [SerializeField]
    private float alpha;

    public Sprite potionWhite;
    public Sprite potionRed;
    public Sprite potionGreen;
    public Sprite potionBlue;
    public Sprite potionCyan;
    public Sprite potionMagenta;
    public Sprite potionYellow;

    public Item itemWhite;
    public Item itemRed;
    public Item itemGreen;
    public Item itemBlue;
    public Item itemCyan;
    public Item itemMagenta;
    public Item itemYellow;

    public bool redState;
    public bool greenState;
    public bool blueState;

    public static ColorManager instance
    {
        get
        {
            if (_colorManager == null)
            {
                _colorManager = FindObjectOfType<ColorManager>();
            }

            return _colorManager;
        }
    }

    private static ColorManager _colorManager;

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 ColorManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴 - 중복 생성 막기
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        potion.sprite = potionWhite;
        rgbLight.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, alpha / 255f);
        redState = true;
        greenState = true;
        blueState = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        if(redState && greenState && blueState)
        {
            rgbLight.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, alpha / 255f);
            potion.sprite = potionWhite;
            pickupPotions.item = itemWhite;
        }
        else if (redState && greenState)
        {
            rgbLight.color = new Color(255 / 255f, 255 / 255f, 0 / 255f, alpha / 255f);
            potion.sprite = potionYellow;
            pickupPotions.item = itemYellow;
        }
        else if (redState && blueState)
        {
            rgbLight.color = new Color(255 / 255f, 0 / 255f, 255 / 255f, alpha / 255f);
            potion.sprite = potionMagenta;
            pickupPotions.item = itemMagenta;
        }
        else if (greenState && blueState)
        {
            rgbLight.color = new Color(0 / 255f, 255 / 255f, 255 / 255f, alpha / 255f);
            potion.sprite = potionCyan;
            pickupPotions.item = itemCyan;
        }
        else if (redState)
        {
            rgbLight.color = new Color(255 / 255f, 0 / 255f, 0 / 255f, alpha / 255f);
            potion.sprite = potionRed;
            pickupPotions.item = itemRed;
        }
        else if (greenState)
        {
            rgbLight.color = new Color(0 / 255f, 255 / 255f, 0 / 255f, alpha / 255f);
            potion.sprite = potionGreen;
            pickupPotions.item = itemGreen;
        }
        else if (blueState)
        {
            rgbLight.color = new Color(0 / 255f, 0 / 255f, 255 / 255f, alpha / 255f);
            potion.sprite = potionBlue;
            pickupPotions.item = itemBlue;
        }
        else
        {
            rgbLight.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, alpha / 255f);
            potion.sprite = potionWhite;
            pickupPotions.item = itemWhite;
        }
    }
}
