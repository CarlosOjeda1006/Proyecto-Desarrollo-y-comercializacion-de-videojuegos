using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject resourcePrefab;
    public float spawnInterval = 3f;
    public Vector2 spawnAreaMin = new Vector2(-3, -3);
    public Vector2 spawnAreaMax = new Vector2(3, 6);

    void Start()
    {
        if (resourcePrefab == null)
        {
            Debug.LogError("ResourceSpawner: No se asignó un prefab de recurso.");
            enabled = false;
            return;
        }

        InvokeRepeating(nameof(SpawnResource), 2f, spawnInterval);
    }

    void SpawnResource()
    {
        if (resourcePrefab == null)
        {
            Debug.LogWarning("ResourceSpawner: resourcePrefab ha sido destruido o no asignado.");
            return;
        }

        Vector2 pos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        try
        {
            Instantiate(resourcePrefab, pos, Quaternion.identity);
        }
        catch (MissingReferenceException e)
        {
            Debug.LogWarning("No se pudo instanciar el recurso: " + e.Message);
        }
    }
}


