using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject CoinPrefab;
    public float radius = 7;

    //Spawn Timer
    private float startDelay = 0.2f;
    private float spawnInterval = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjectAtRandom", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObjectAtRandom()
    {
        Vector2 randomPos = Random.insideUnitCircle * radius;
        Instantiate(CoinPrefab, randomPos, Quaternion.identity);
    }
}