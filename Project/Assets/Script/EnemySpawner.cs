using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform baseTransform;
    public float spawnInterval = 5f;
    public Vector2 spawnAreaMin = new Vector2(-5, 8);
    public Vector2 spawnAreaMax = new Vector2(5, 12);

    void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("EnemySpawner: No se asignó un prefab de enemigo.");
            enabled = false;
            return;
        }

        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        EnemyAI ai = enemy.GetComponent<EnemyAI>();
        if (ai != null && baseTransform != null)
        {
            ai.baseTransform = baseTransform;
        }
    }
}

