using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject resourcePrefab;
    public float spawnInterval = 3f;
    public Vector2 spawnAreaMin = new Vector2(-3, -3);
    public Vector2 spawnAreaMax = new Vector2(3, 6);
    public int maxResources = 3;

    void Start()
    {
        InvokeRepeating(nameof(SpawnResource), 2f, spawnInterval);
    }

    void SpawnResource()
    {
        GameObject[] existing = GameObject.FindGameObjectsWithTag("Resource");
        if (existing.Length >= maxResources) return;

        Vector2 pos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        Instantiate(resourcePrefab, pos, Quaternion.identity);
    }
}



