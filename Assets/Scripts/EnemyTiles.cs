using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTiles : MonoBehaviour
{
    private Transform lastUsedTile;
    System.Random rand = new System.Random();

    private List<Transform> enemyTiles = new List<Transform>();

    void Start()
    {
        foreach (Transform child in this.transform)
        {
            enemyTiles.Add(child);
        }
    }
    public Vector3 GetRandomTile()
    {
        int tileAddress = rand.Next(enemyTiles.Count - 1);
        Transform targetTile = enemyTiles[tileAddress];
        if(lastUsedTile != null)
        {
            enemyTiles.Add(lastUsedTile);
        }
        lastUsedTile = targetTile;
        enemyTiles.Remove(targetTile);
        Vector3 randomDisplace = new Vector3((float)rand.NextDouble(), (float)rand.NextDouble(), 0f);
        return targetTile.position + randomDisplace;
    }
}
