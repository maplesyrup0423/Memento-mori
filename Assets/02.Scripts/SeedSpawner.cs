using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    public GameObject seedPrefeb;
    public GameObject parent;
    private float interval, time;
    private float minTime, maxTime;
    private int minX, maxX, posY;

    // Start is called before the first frame update
    void Start()
    {
        minTime = 0.5f;
        maxTime = 1.5f;

        time = 0;
        interval = Random.Range(minTime, maxTime);

        minX = -7;
        maxX = 7;
        posY = 6;
    }

    private void Update()
    {
        CreateSeed();
    }

    private void CreateSeed()
    {
        time += Time.deltaTime;

        if (time >= interval)
        {
            time = 0;
            GameObject seed = Instantiate(seedPrefeb);
            seed.transform.parent = parent.transform;
            seed.transform.localPosition = new Vector3(Random.Range(minX, maxX), posY, 0);
            interval = Random.Range(minTime, maxTime);
        }
    }
}
