using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public float progressValue = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ProgressManager.Instance.AddProgress(progressValue);
            Destroy(gameObject);


        }
    }
}

