using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public float spawnRangeX = 77;
    public float spawnPosY = -0.24f;
    private float spawnDelay = 3;
    private float spawnInterval = 3f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemies", spawnDelay, spawnInterval);
    }


    void SpawnRandomEnemies()
    {
        int enemiesIndex = Random.Range(0, enemiesPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range( 0, spawnRangeX), -0.24f, spawnPosY);

        Instantiate(enemiesPrefabs[enemiesIndex], spawnPos, enemiesPrefabs[enemiesIndex].transform.rotation);

    }
}
