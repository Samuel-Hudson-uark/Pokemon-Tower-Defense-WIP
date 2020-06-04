using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyTileSection;
    EnemyTiles enemyTiles;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f;
    private readonly int[] waves = { 1, 1, 2, 3, 5 };
    private int waveCount = 0;
    private float waveDelay = 1f;

    void Start()
    {
        enemyTiles = enemyTileSection.GetComponent<EnemyTiles>();
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f && waveCount < waves.Length)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        int enemyCount = waves[waveCount];
        waveCount++;
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(waveDelay);
        }
        
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, enemyTiles.GetRandomTile(), enemyTileSection.transform.rotation);
    }
}
