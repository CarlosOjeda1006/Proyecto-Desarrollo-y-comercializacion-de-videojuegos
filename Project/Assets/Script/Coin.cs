using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoins(value);
            Destroy(gameObject);
        }
    }
}


