using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaves
{
    [Tooltip("time for wave generation from the moment the game started")]
    public float waveInterval;

    [Tooltip("Enemy wave's prefab")]
    public GameObject wave;
}
public class WaveController : MonoBehaviour
{
    public static WaveController instance;
    [HideInInspector]public float multiplierLevel = 1f;
    public float multiplier = 1f;
    //Serializable classes implements
    public EnemyWaves[] enemyWaves;
    public int level;
    private float currentTime;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        GameStart();
    }
    public void GameStart()
    {
        CreateEnemyWave(enemyWaves[level].wave);
        currentTime = 0;
    }

    void Update()
    {
        //if(!GameManager.instance.gameStarted)
           // return;
        currentTime = currentTime + Time.deltaTime;
        if (currentTime > enemyWaves[level].waveInterval)
        {
            NextWave();
            currentTime = 0;
            CreateEnemyWave(enemyWaves[level].wave);
        }
    }
    public void ResetGame()
    {
        level = 0;
        multiplierLevel = 1f;
        currentTime = 0;
    }
    public void NextWave()
    {   
        level++;
        if(level >= enemyWaves.Length)
        {
            level = 0;
            multiplierLevel += multiplier;
        }
        
    }
    //Create a new wave after a delay
    public void CreateEnemyWave(GameObject Wave)
    {
        if (Player.instance != null){
            Instantiate(Wave);
        }
    }
}
