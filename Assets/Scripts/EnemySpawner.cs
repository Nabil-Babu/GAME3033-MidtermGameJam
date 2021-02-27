using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int spawnLimit = 1; 
    
    public void SpawnEnemy()
    {
        StartCoroutine(SpawnAllEnemies());
    }

    IEnumerator SpawnAllEnemies()
    {
        for (int i = 0; i < spawnLimit; i++)
        {
            yield return new WaitForSeconds(1.0f);
            Instantiate(EnemyPrefab); 
        }
        
    }
}
