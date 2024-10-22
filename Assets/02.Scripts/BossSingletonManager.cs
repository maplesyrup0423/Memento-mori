using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSingletonManager : MonoBehaviour
{
    private static BossSingletonManager _instance; // 싱글톤이 할당될 static 변수
    public BossAttack2D bossAttack2D;

    // 싱글톤 접근용 프로퍼티
    public static BossSingletonManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (_instance == null)
            {
                // 씬에서 BossSingletonManager 오브젝트를 찾아 할당
                _instance = FindObjectOfType<BossSingletonManager>();
            }

            // 싱글톤 오브젝트를 반환
            return _instance;
        }
    }

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 BossSingletonManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }

    public void OnBossAttack2D()
    {
        bossAttack2D.gameObject.SetActive(true);
    }

    public void OffBossAttack2D()
    {
        bossAttack2D.gameObject.SetActive(false);
    }
}
