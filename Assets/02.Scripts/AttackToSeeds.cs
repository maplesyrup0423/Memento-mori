using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackToSeeds : MonoBehaviour
{
    float maxDistance;  // 레이캐스트용 변수
    Vector3 mousePos;   // 마우스 위치를 받는 변수

    public Transform goal;
    public float speed;

    private EffectSoundController effectSound;
    private Vector3 goalPos;
    private int damage;

    GameObject seed;

    private void Start()
    {
        seed = gameObject;
        speed = 8.0f;
        effectSound = GameObject.Find("B1_EffectSoundController").GetComponent<EffectSoundController>();
        goal = GameObject.Find("Goal").GetComponent<Transform>();
        goalPos = new Vector3(transform.position.x, goal.position.y, 0);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goalPos, speed * Time.deltaTime);

        // 레이캐스트 : 마우스 위치로 피격 검사
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        int layerMask = 1 << LayerMask.NameToLayer("AttackArea");
        RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, maxDistance, layerMask);

        if (hit)
        {
            if (hit == gameObject)
            {
                Debug.Log(hit.collider.name + " : 공격에 맞았습니다");
                effectSound.PlayDamageOnPlayer();
                damage = BossSingletonManager.instance.bossAttack2D.playerDamage;
                BossSingletonManager.instance.bossAttack2D.playerHP -= damage;
                BossSingletonManager.instance.bossAttack2D.playerHpBar.HP_Control(-damage);
                Destroy(hit.collider.gameObject);
            }        
        }

        if (transform.position.y <= goal.position.y)
        {
            Debug.Log("끝에 닿았습니다.");
            damage = BossSingletonManager.instance.bossAttack2D.bossDamage;
            BossSingletonManager.instance.bossAttack2D.bossHP -= damage;
            BossSingletonManager.instance.bossAttack2D.bossHpBar.HP_Control(-damage);
            Destroy(seed);
        }
        
    }
}
