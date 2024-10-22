using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerState : MonoBehaviour
{
    public Image hp_bar_player;
    public int maxHp = 100;

    private float hp;

    private void Start() {
        hp = maxHp;
    }


    public void HP_Control(int value) {
        hp += value;
        hp_bar_player.fillAmount = hp / maxHp;
    }

    public void Life_Control(int value) {
        PlayerData.Data_Player_Life -= value;
    }
}