using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform[] SpawnLocations;
    public int spawnLimit = 1; 
    
    public void SpawnEnemy()
    {
        StartCoroutine(SpawnAllEnemies());
    }

    IEnumerator SpawnAllEnemies()
    {
        for (int i = 0; i < spawnLimit; i++)
        {
            yield return new WaitForSeconds(1.5f);
            GameObject temp = Instantiate(EnemyPrefab);
            temp.transform.position = SpawnLocations[Random.Range(0, SpawnLocations.Length)].position;
        }
        
    }
}
