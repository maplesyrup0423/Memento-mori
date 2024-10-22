using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check2DAttacked : MonoBehaviour
{
    /*
    [SerializeField]
    private float delayTime; // 난이도에 따른 공격 시간 변수
    [SerializeField]
    private GameObject background;

    private float maxDistance;  // 레이캐스트용 변수
    private Vector3 mousePos;   // 마우스 위치를 받는 변수
    public BossAttack2D bossAttack2D;
    public UI_PlayerState bossHpBar;
    public UI_PlayerState playerHpBar;
    private static bool isDamaged;

    private void OnEnable()
    {
        isDamaged = false;
        delayTime = bossAttack2D.attackTime;
        CheckAttacked();
    }

    private void CheckAttacked()
    {
        StartCoroutine(CoroutineCheckAttacked());
    }

    IEnumerator CoroutineCheckAttacked()
    {

        // 단일 공격 대기 시간
        yield return new WaitForSeconds(delayTime);

        // 레이캐스트 : 마우스 위치로 피격 검사
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, maxDistance);
        Debug.DrawRay(mousePos, transform.forward * 10, Color.red, 0.3f);

        if (hit && hit.transform.tag == "AttackPattern")
        {
            isDamaged = true;
        }
        
        if (isDamaged)
        {
            Debug.Log(hit.collider.name + " : 공격에 맞았습니다");
            // hp 조절 자리
            bossAttack2D.playerHP -= bossAttack2D.playerDamage;
            playerHpBar.HP_Control(-bossAttack2D.playerDamage);
        }
        else
        {
            Debug.Log("공격을 피했습니다");
            bossAttack2D.bossHP -= bossAttack2D.bossDamage;
            bossHpBar.HP_Control(-bossAttack2D.bossDamage);
        }

        gameObject.SetActive(false);
        background.SetActive(false);
    }
    */
}
