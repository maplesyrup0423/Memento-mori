using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    // 아이템 이름
    public string itemName;
    // 게임씬 안에서의 스프라이트
    public Sprite itemImage;
    // 인벤토리에서의 스프라이트
    public Sprite inSlotImage;
}
