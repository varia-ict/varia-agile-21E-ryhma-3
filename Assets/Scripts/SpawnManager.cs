using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public float spawnRangeX = 40;
    public float spawnPosY = 0;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemies", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomEnemies();
        }
    }

    void SpawnRandomEnemies()
    {
        int enemiesIndex = Random.Range(0, enemiesPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range( 0, spawnRangeX), 0, spawnPosY);

        Instantiate(enemiesPrefabs[enemiesIndex], spawnPos, enemiesPrefabs[enemiesIndex].transform.rotation);

    }
}
