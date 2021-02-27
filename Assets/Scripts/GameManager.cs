using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject GameOverText; 
    public GameObject VictoryText; 
    public EnemySpawner EnemySpawner;
    public SceneLoader SceneLoader;
    public int WinLimit; 
    public int currentScore = 0; 

    void Start()
    {
        WinLimit = EnemySpawner.spawnLimit;
        Invoke(nameof(StartBattle), 5.0f);
    }
    
    public void StartBattle()
    {
        Instructions.SetActive(false);
        EnemySpawner.SpawnEnemy();
    }

    public void GameOver()
    {
        GameOverText.SetActive(true);
        Invoke(nameof(LoadMainMenu), 1.5f);
    }

    public void LoadMainMenu()
    {
        SceneLoader.MainMenu();
    }

    public void Victory()
    {
        VictoryText.SetActive(true);
        Invoke(nameof(LoadMainMenu), 1.5f);
    }

    public void IncreaseKillCount()
    {
        currentScore++;
        if (currentScore == WinLimit)
        {
            Victory();
        }
    }
    
}
