using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InArray
{
    public GameObject[] inArray;
}

public class BossAttack2D : MonoBehaviour
{
    public GameObject gameClear;
    public int bossHP = 300, playerHP = 100;

    public GameObject boss, grass;
    public GameObject patternGroup;
    public GameObject dropGroup;

    public GameObject next;

    public EffectSoundController effectSound;
    public Image displayImg;

    [HideInInspector]
    public int bossDamage, playerDamage;
    
    public UI_PlayerState bossHpBar;
    public UI_PlayerState playerHpBar;
    private bool dieBoss, diePlayer;

    public InArray[] patternSet;
    public InArray[] patternBackgroundSet;

    private float attackTime;   // 난이도에 따른 공격 시간 변수
    private float delayTime; // 연속공격용 딜레이 시간 변수
    private Animator bossAnimator;
    private Animator grassAnimator;

    float maxDistance;  // 레이캐스트용 변수
    int x, y;           // 패턴 배열 인덱스용 변수
    Vector3 mousePos;   // 마우스 위치를 받는 변수

    private void Awake()
    {

        dieBoss = false;
        diePlayer = false;

        bossDamage = 25;
        playerDamage = 10;

        maxDistance = 15f;
        bossAnimator = boss.GetComponent<Animator>();
        grassAnimator = grass.GetComponent<Animator>();

        attackTime = 1.0f;
        boss.SetActive(true);
    }

    private void Update()
    {
        if (bossHP == 0)
        {
            if (!dieBoss)
            {
                dieBoss = true;
                StopAllCoroutines();
                StartCoroutine(CoroutineDieBoss());
            }
        }
        
        else if (playerHP == 0)
        {
            if (!diePlayer)
            {
                diePlayer = true;
                StopAllCoroutines();
                StartCoroutine(CoroutineDiePlayer());
            }

        }
    }

    //보스 스테이지 이동 시 이 스크립트가 붙은 오브젝트를 활성화해야함.
    private void OnEnable()
    {
        Debug.Log("0");
        StartCoroutine(CoroutineAppearBoss());
    }

    IEnumerator CoroutineAppearBoss()
    {
        displayImg.enabled = true;
        displayImg.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 235 / 255f);
        effectSound.PlayAppearBoss();
        StartCoroutine(OnDisplayImage(0));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("ChooseAttackType");

    }

    IEnumerator ChooseAttackType()
    {
        Debug.Log("공격을 선택합니다.");

        // 다음 공격까지의 텀
        yield return new WaitForSeconds(1.5f);

        // ----------------------- 공격 패턴 선택 -----------------------

        // 300 ~ 200 - 쉬움
        if (bossHP >= 200)
        {
            Debug.Log("1단계 공격 선택");

            int randomAtk = Random.Range(0, 4);
            switch (randomAtk)
            {
                case 0:
                case 1:
                case 2:
                    // 단일 공격
                    StartCoroutine("SelectSingleAttackArea");
                    break;
                case 3:
                case 4:
                    // 연속 공격
                    StartCoroutine("SelectContinuousAttackArea");
                    break;
            }

        }
        else if (bossHP >= 100) // 100 ~ 199 - 보통
        {
            Debug.Log("2단계 공격 선택");

            int randomAtk = Random.Range(0, 5);
            switch (randomAtk)
            {
                case 0:
                case 1:
                case 2:
                    // 단일 공격
                    StartCoroutine("SelectSingleAttackArea");
                    break;
                case 3:
                case 4:
                    // 연속 공격
                    StartCoroutine("SelectContinuousAttackArea");
                    break;
                case 5:
                    // 낙하 공격
                    StartCoroutine("DropAttack");
                    break;
            }
        }
        else // 0 ~ 99 - 어려움
        {
            Debug.Log("3단계 공격 선택");

            int randomAtk = Random.Range(0, 5);
            switch (randomAtk)
            {
                case 0:
                case 1:
                case 2:
                    // 단일 공격
                    StartCoroutine("SelectSingleAttackArea");
                    break;
                case 3:
                    // 연속 공격
                    StartCoroutine("SelectContinuousAttackArea");
                    break;
                case 4:
                case 5:
                    // 낙하 공격
                    StartCoroutine("DropAttack");
                    break;
            }
        }

    }


    // 단일공격할 패턴선택
    IEnumerator SelectSingleAttackArea()
    {
        // 다음 공격까지의 텀
        yield return new WaitForSeconds(1.0f);

        bossDamage = 10;
        playerDamage = 20;

        // 300 ~ 200 - 쉬움
        if(bossHP >= 200)
        {
            Debug.Log("1단계 단일 공격!");
            int randomAtk = Random.Range(0, 8);
            switch(randomAtk)
            {
                case 0:
                case 1:
                    // 1/4 세로 공격 2줄
                    SetQuartersAttack(0, 2);
                    break;
                case 2:
                case 3:
                    // 1/4 가로 공격 2줄
                    SetQuartersAttack(2, 2);
                    break;
                case 4:
                    //랜덤 1/8 원형 4개 공격
                    SetQuartersAttack(4, 4);
                    break;
                case 5:
                    // 십자 공격
                    SetCrossAttack();
                    break;
                case 6:
                    // 1/8 원형 한줄 공격
                    SetFourCircleAttack(Random.Range(0, 1));
                    break;
                case 7:
                    // + x 원형 공격
                    SetFourCircleAttack(Random.Range(0, 1));
                    break;
                case 8:
                    // 반쪽 랜덤 1개 공격
                    SetHalfRandomAttack(Random.Range(0, 1));
                    break;
                default:
                    Debug.Log("여긴 스위치문 1의 디폴트");
                    break; 
            }

        }
        else if (bossHP >= 100) // 100 ~ 199 - 보통
        {
            Debug.Log("2단계 단일 공격!");

            int randomAtk = Random.Range(0, 11);
            switch (randomAtk)
            {
                case 0:
                case 1:
                case 2:
                    // 1/4 세로 공격 3줄
                    SetQuartersAttack(0, 3);
                    break;
                case 3:
                case 4:
                case 5:
                    // 1/4 가로 공격 3줄
                    SetQuartersAttack(2, 3);
                    break;
                case 6:
                case 7:
                    // 1/8 원형 공격 랜덤 6개
                    SetQuartersAttack(4, 6);
                    break;
                case 8:
                    // 반쪽 2개 가로/세로 랜덤 공격
                    SetRandomFullHalfAttack(Random.Range(0, 1));
                    break;
                case 9: 
                    // v 원형 공격
                    SetCircleDownSideAttack();
                    break;
                case 10:
                    // ^ 원형 공격
                    SetCircleUpSideAttack();
                    break;
                case 11:
                    // + x 원형 겹치기 공격
                    SetFourCircleAttack(0);
                    SetFourCircleAttack(1);
                    break;
                default:
                    Debug.Log("여긴 스위치문 2의 디폴트");
                    break;
            }


        }
        else // 0 ~ 99 - 어려움
        {
            Debug.Log("3단계 단일 공격!");

            int randomAtk = Random.Range(0, 11);
            switch (randomAtk)
            {
                case 0:
                case 1:
                case 2:
                    // 십자 + 모서리 공격
                    SetCrossAttack();
                    SetConnerAttack();
                    break;
                case 3:
                case 4:
                case 5:
                    // 1/4 세로 2줄 + 1/4 가로 2줄
                    SetQuartersAttack(0, 2);
                    SetQuartersAttack(2, 2);
                    break;
                case 6:
                case 7:
                    // 1/8 원형 공격 랜덤 7개
                    SetQuartersAttack(4, 7);
                    break;
                case 8:
                    // + x 원형 + 모서리 겹치기 공격
                    SetFourCircleAttack(0);
                    SetFourCircleAttack(1);
                    SetConnerAttack();
                    break;
                case 9:
                    // 가로 반쪽 + 1/4 세로 3개 공격
                    SetHalfRandomAttack(0);
                    SetQuartersAttack(0, 3);
                    break;
                case 10:
                    // 세로 반쪽 + 1/4 가로 3개 공격
                    SetHalfRandomAttack(1);
                    SetQuartersAttack(2, 3);
                    break;
                case 11:
                    // 반쪽 4개 공격
                    SetHalfHorizontalAttack();
                    SetHalfVerticalAttack();
                    break;
                default:
                    Debug.Log("여긴 스위치문 3의 디폴트");
                    break;
            }

        }

        StartCoroutine("SingleAttack");
    }

    // 실제로 단일 공격 피격 판정을 할 코루틴
    IEnumerator SingleAttack()
    {
        // 단일 공격 대기 시간
        yield return new WaitForSeconds(attackTime);

        // 레이캐스트 : 마우스 위치로 피격 검사
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        int layerMask = 1 << LayerMask.NameToLayer("AttackArea");
        RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, maxDistance, layerMask);
        // Debug.DrawRay(mousePos, transform.forward * 10, Color.red, 0.3f);

        if (hit)
        {
            Debug.Log(hit.collider.name + " : 공격에 맞았습니다");
            // hp 조절 자리
            effectSound.PlayDamageOnPlayer();
            playerHP -= playerDamage;
            playerHpBar.HP_Control(-playerDamage);
            OffAllPattern();
            StartCoroutine(CoroutineOnDamagePlayer());
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            Debug.Log("공격을 피했습니다");
            effectSound.PlayDamageOnBoss();
            bossHP -= bossDamage;
            bossHpBar.HP_Control(-bossDamage);
        }

        OffAllPattern();
        StartCoroutine("ChooseAttackType");
    }


    // 연결 공격할 패턴선택
    void SelectContinuousAttackArea()
    {
        bossDamage = 5;
        playerDamage = 20;
        attackTime = 0.5f;

        int randomAtk = Random.Range(0, 8);
        switch (randomAtk)
        {
            case 0:
            case 1:
            case 2:
                // 세로 1/4
                delayTime = 0.5f;
                StartCoroutine(SetContinuousPattern(0));
                break;
            case 3:
            case 4:
            case 5:
                delayTime = 0.5f;
                // 가로 1/4
                StartCoroutine(SetContinuousPattern(2));
                break;
            case 6:
                // 원형 ^
                delayTime = 0.25f;
                StartCoroutine(SetContinuousPattern(5));
                break;
            case 7:
                // 원형 v
                delayTime = 0.25f;
                StartCoroutine(SetContinuousPattern(6));
                break;
            case 8:
                // 원형 1/8
                delayTime = 0.25f;
                StartCoroutine(SetContinuousPattern(4));
                break;
        }
    }

    // 연속 공격의 영역 키는 코루틴
    // num : 킬 패턴 영역의 인덱스 번호
    IEnumerator SetContinuousPattern(int num)
    {
        for (int i = 0; i < patternSet[num].inArray.Length; i++)
        {
            patternSet[num].inArray[i].SetActive(true);
            patternBackgroundSet[num].inArray[i].SetActive(true);
            yield return new WaitForSeconds(delayTime);
        }

        StartCoroutine(ContinuousAttack(num));
    }

    // 연속 공격 코루틴
    IEnumerator ContinuousAttack(int num)
    {
        Debug.Log("연속 공격!");

        for (int i = 0; i < patternSet[num].inArray.Length; i++)
        {


            // 레이캐스트 : 마우스 위치로 피격 검사
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            int layerMask = 1 << LayerMask.NameToLayer("AttackArea");
            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, maxDistance, layerMask);
            // Debug.DrawRay(mousePos, transform.forward * 10, Color.red, 0.3f);

            if (hit && hit.collider.name == patternSet[num].inArray[i].name)
            {
                Debug.Log(hit.collider.name + " : 공격에 맞았습니다");
                // hp 조절 자리
                effectSound.PlayDamageOnPlayer();
                playerHP -= playerDamage;
                playerHpBar.HP_Control(-playerDamage);
                patternSet[num].inArray[i].SetActive(false);
                patternBackgroundSet[num].inArray[i].SetActive(false);
                StartCoroutine(CoroutineOnDamagePlayer());
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                Debug.Log("공격을 피했습니다");
                effectSound.PlayDamageOnBoss();
                bossHP -= bossDamage;
                bossHpBar.HP_Control(-bossDamage);
            }

            patternSet[num].inArray[i].SetActive(false);
            patternBackgroundSet[num].inArray[i].SetActive(false);

            yield return new WaitForSeconds(attackTime);
        }

        StartCoroutine("ChooseAttackType");

    }
    
    // 낙하 공격 코루틴
    IEnumerator DropAttack()
    {
        Debug.Log("낙하 공격!");

        bossDamage = 5;
        playerDamage = 10;

        dropGroup.SetActive(true);
        yield return new WaitForSeconds(10f);
        dropGroup.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        StartCoroutine("ChooseAttackType");
    }

    // 보스의 Die 애니메이션 + 효과음 출력 코루틴
    IEnumerator CoroutineDieBoss()
    {

        Debug.Log("보스를 죽였습니다. 말라서 사라집니다.");

        patternGroup.SetActive(false);
        dropGroup.SetActive(false);

        effectSound.PlayDieBoss();

        grassAnimator.SetTrigger("Die2");
        bossAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(5.2f);
        next.SetActive(true);
        boss.SetActive(false);
        grass.SetActive(false);
        BossSingletonManager.instance.OffBossAttack2D();

        yield return new WaitForSeconds(0.5f);

        PlayerPrefs.SetInt("Data_Stage5_Clear", 1);
        PlayerPrefs.SetInt("CurrentStage", 6);
        PlayerData.Data_Stage5_Clear = true;
        PlayerData.CurrentStage = 6;
        PlayerData.instance.CallResultScene(Result_State.main);
        gameClear.SetActive(true);
    }

    // 플레이어의 Die 처리 + 효과음 출력 코루틴
    IEnumerator CoroutineDiePlayer()
    {
        Debug.Log("플레이어가 죽었습니다.");

        patternGroup.SetActive(false);
        dropGroup.SetActive(false);

        effectSound.PlayDiePlayer();
        StartCoroutine(OnDisplayImage(0));
        yield return new WaitForSeconds(2.5f);

        PlayerPrefs.SetString("SelectedItemKey", "nothing");
        PlayerData.Data_Player_Life -= 1;
        PlayerData.instance.CallResultScene(Result_State.main);
    }

    IEnumerator OnDisplayImage(int red)
    {
        int alpha = 235;

        while (alpha >= 0)
        {
            alpha -= 5;
            displayImg.color = new Color(red / 255f, 0 / 255f, 0 / 255f, alpha / 255f);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);
        displayImg.enabled = false;
    }

    IEnumerator CoroutineOnDamagePlayer()
    {
        displayImg.color = new Color(255 / 255f, 10 / 255f, 10 / 255f, 180 / 255f);
        displayImg.enabled = true;
        yield return new WaitForSeconds(0.4f);
        displayImg.enabled = false;
    }

    // 모든 패턴 끄기
    void OffAllPattern()
    {
        for (int i = 0; i < patternSet.Length; i++)
        {
            int length = patternSet[i].inArray.Length;
            for (int j = 0; j < length; j++)
            {
                patternSet[i].inArray[j].SetActive(false);
                patternBackgroundSet[i].inArray[j].SetActive(false);
            }
        }
    }

    // -------------------- V V V 공격 패턴 영역 키는 메소드 V V V --------------------

    // 랜덤 영역 패턴(int patternSet 인덱스, int 공격영역 수)
    // ptnNum | 0: 1/4 세로 | 2: 1/4 가로 | 4: 1/8 원
    void SetQuartersAttack(int ptnNum,int lineNum) {
        int[] index = new int[lineNum];

        // 랜덤 인덱스 추첨
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = Random.Range(0, patternSet[ptnNum].inArray.Length - 1);
            // 중복 방지
            for (int j = 0; j < i; j++)
            {
                if (index[i] == index[j])
                {
                    i--;
                }
            }
        }

        // 랜덤추첨한 번호의 인덱스 영역 모두 키기
        for(int i = 0; i < index.Length; i++) 
        {
            patternSet[ptnNum].inArray[index[i]].SetActive(true);
            patternBackgroundSet[ptnNum].inArray[index[i]].SetActive(true);
        }
    }

    // 1/8 원 가로/세로 한줄 패턴(int line, int lineNum)
    // line | 0: 가로 | 1: 세로
    void SetSingleCircleLineAttack(int line)
    {
        // 가로 1줄 랜덤
        if(line == 0)
        {
            int num = patternSet[4].inArray.Length;
            int x = Random.Range(0, num - 1);
            for (int i = 0; i < num/2; i++)
            {
                patternSet[4].inArray[i].SetActive(true);
                patternBackgroundSet[4].inArray[i].SetActive(true);
            }
        } 
        // 세로 1줄 랜덤
        else
        {
            int num = patternSet[4].inArray.Length;
            int x = Random.Range(0, 3);
            patternSet[4].inArray[x].SetActive(true);
            patternBackgroundSet[4].inArray[x].SetActive(true);
            patternSet[4].inArray[x+4].SetActive(true);
            patternBackgroundSet[4].inArray[x+4].SetActive(true);
        }
    }

    // 1/4 원형 1 방향 패턴(int line)
    // line | 0: + | 1: x
    void SetFourCircleAttack(int line)
    {
        // 원형 4개 + 모양
        if (line == 0)
        {
            int num = patternSet[7].inArray.Length;
            for (int i = 0; i < num; i++)
            {
                patternSet[7].inArray[i].SetActive(true);
                patternBackgroundSet[7].inArray[i].SetActive(true);
            }
        }
        // 원형 4개 x 모양
        else
        {
            int num = patternSet[8].inArray.Length;
            for (int i = 0; i < num; i++)
            {
                patternSet[8].inArray[i].SetActive(true);
                patternBackgroundSet[8].inArray[i].SetActive(true);
            }
        }
    }

    // 원형 △ 패턴
    void SetCircleUpSideAttack()
    {
        int num = patternSet[5].inArray.Length;
        for (int i = 0; i < num; i++)
        {
            patternSet[5].inArray[i].SetActive(true);
            patternBackgroundSet[5].inArray[i].SetActive(true);
        }
    }

    // 원형 ▽ 패턴
    void SetCircleDownSideAttack()
    {
        int num = patternSet[6].inArray.Length;
        for (int i = 0; i < num; i++)
        {
            patternSet[6].inArray[i].SetActive(true);
            patternBackgroundSet[6].inArray[i].SetActive(true);
        }
    }

    // 모서리 4개 패턴
    void SetConnerAttack()
    {
        int num = patternSet[9].inArray.Length;
        for (int i = 0; i < num; i++)
        {
            patternSet[9].inArray[i].SetActive(true);
            patternBackgroundSet[9].inArray[i].SetActive(true);
        }
    }

    // 십자 패턴
    void SetCrossAttack()
    {
        Debug.Log("십자 공격!");
        x = Random.Range(0, 1);
        y = Random.Range(0, patternSet[x].inArray.Length - 1);
        patternSet[x].inArray[y].SetActive(true);
        patternBackgroundSet[x].inArray[y].SetActive(true);
        x = Random.Range(2, 3);
        y = Random.Range(0, patternSet[x].inArray.Length - 1);
        patternSet[x].inArray[y].SetActive(true);
        patternBackgroundSet[x].inArray[y].SetActive(true);
    }

    // 반쪽 1개 공격(int line)
    // line | 0: 가로 | 1: 세로
    void SetHalfRandomAttack(int line)
    {
        // 1/2 가로 1개 랜덤
        if (line == 0)
        {
            int x = Random.Range(0, 1);
            patternSet[3].inArray[x].SetActive(true);
            patternBackgroundSet[3].inArray[x].SetActive(true);
        }
        // 1/2 세로 1개 랜덤
        else
        {
            int x = Random.Range(0, 1);
            patternSet[1].inArray[x].SetActive(true);
            patternBackgroundSet[1].inArray[x].SetActive(true);
        }
    }

    // 세로 반쪽 2개로 거의 전체 공격
    void SetHalfVerticalAttack()
    {
        patternSet[1].inArray[0].SetActive(true);
        patternBackgroundSet[1].inArray[0].SetActive(true);
        patternSet[1].inArray[1].SetActive(true);
        patternBackgroundSet[1].inArray[1].SetActive(true);
    }

    // 가로 반쪽 2개로 거의 전체 공격
    void SetHalfHorizontalAttack()
    {
        patternSet[3].inArray[0].SetActive(true);
        patternBackgroundSet[3].inArray[0].SetActive(true);
        patternSet[3].inArray[1].SetActive(true);
        patternBackgroundSet[3].inArray[1].SetActive(true);
    }

    // 반쪽 2개 공격 - 랜덤(int line)
    // line | 0: 가로 | 1: 세로
    void SetRandomFullHalfAttack(int line)
    {
        // 가로
        if (line == 0)
        {
            SetHalfHorizontalAttack();
        }
        //세로
        else
        {
            SetHalfVerticalAttack();
        }
    }

}
