using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int spawnRange = 9;
    private int enemyCount;
    private int waveCount = 1;
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWave(waveCount);
        Instantiate(powerupPrefab, generateSpawnPosition(), powerupPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        //What we are looking for is the scripts called Enemy,
        //1 for each spawned enemy on scene
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            spawnEnemyWave(waveCount);
            Instantiate(powerupPrefab, generateSpawnPosition(), powerupPrefab.transform.rotation);
            waveCount++;
        }
    }
    void spawnEnemyWave (int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn;  i++)
        {
        Instantiate(enemyPrefab, generateSpawnPosition(), 
        enemyPrefab.transform.rotation);
        }

    }
    private Vector3 generateSpawnPosition()
    {
        int randomX = Random.Range(-spawnRange, spawnRange);
        int randomY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(randomX,0,randomY);
        return randomPosition;
    }
}
