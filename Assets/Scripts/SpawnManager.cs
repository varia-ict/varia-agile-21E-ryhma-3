using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] enemiesPrefabs;
    public float spawnRangeX1 = 93;
    public float spawnRangeX2 = 18;
    public float spawnPosY;
    private float spawnDelay = 3;
    private float spawnInterval = 3f;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemies", spawnDelay, spawnInterval);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    void SpawnRandomEnemies()
    {
        int enemiesIndex = Random.Range(0, enemiesPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range( spawnRangeX2, spawnRangeX1), spawnPosY);

        if (!gameManager.gameOver)
        {
            Instantiate(enemiesPrefabs[enemiesIndex], spawnPos, enemiesPrefabs[enemiesIndex].transform.rotation);
        }
        

    }
}
