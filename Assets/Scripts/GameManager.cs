using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Instructions;
    public EnemySpawner EnemySpawner; 


    void Start()
    {
        Invoke(nameof(StartBattle), 5.0f);
    }
    
    public void StartBattle()
    {
        Instructions.SetActive(false);
        EnemySpawner.SpawnEnemy();
    }
}
