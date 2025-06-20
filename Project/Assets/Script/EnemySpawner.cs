using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public float spawnInterval = 5f;
    public Vector2 spawnAreaMin = new Vector2(-3, -3);
    public Vector2 spawnAreaMax = new Vector2(3, 6);

    private float timer;
    private bool started = false;

    void Start()
    {
        Invoke(nameof(StartSpawning), 1f);
    }

    void StartSpawning()
    {
        started = true;
        timer = spawnInterval;
    }

    void Update()
    {
        if (!started) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnRandomEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Count == 0) return;

        int index = Random.Range(0, enemyPrefabs.Count);
        GameObject enemyToSpawn = enemyPrefabs[index];

        Vector2 spawnPos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
    }
}



