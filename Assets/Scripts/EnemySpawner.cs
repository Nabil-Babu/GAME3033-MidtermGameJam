using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    
    public void SpawnEnemy()
    {
        Debug.Log("Spawning Enemy");
        Instantiate(EnemyPrefab); 
    }
}
