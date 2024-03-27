using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int powerupCount;
    public int enemiesToSpawn;
    public int powerupsToSpawn;

    public GameObject enemyPrefab;
    public GameObject multiplierPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemiesToSpawn = 3;
        SpawnEnemyWave(enemiesToSpawn);

        powerupsToSpawn = 1;
        SpawnPowerupWave(powerupsToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        powerupCount = FindObjectsOfType<MultiplierPowerup>().Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(1);
        }

        if (powerupCount == 0)
        {
            SpawmPowerupWave(1);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerupWave (int numPowerups)
    {
        for (int i = 0; i < numPowerups; i++)
        {
            Instantiate(multiplierPrefab, GenerateSpawnPos(), multiplierPrefab.transform.rotation);
        }
    }
}
