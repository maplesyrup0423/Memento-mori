using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 포션 테이블에서 색깔별로 포션을 꺼내는 스크립트
public class PickupPotions : MonoBehaviour
{
    public Item item;
    private int count;
    private Inventory inven;
    public AudioClip clip;
    private AudioSource audioSource;

    private void Start()
    {
        count = 0;
        inven = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    private void OnMouseUp()
    {
        pickupPotions();
    }

    public void pickupPotions()
    {
        if (count < 6)
        {
            if (PlayerPrefs.HasKey(item.itemName) && PlayerPrefs.GetInt(item.itemName) == 1)
            {
                Debug.Log("이미 획득한 포션입니다.");
            }
            else
            {
                Debug.Log("포션 추가!");
                audioSource.Play();
                inven.AddItem(item);
                count++;
            }

        }
        else if (count == 6)
        {
            Debug.Log("마지막 포션 추가!");
            inven.AddItem(item);
            count++;
            Destroy(gameObject, 0.1f);
        }
        
    }

}
