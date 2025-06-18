using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        ProgressManager.Instance.ReduceProgress(damage * 2);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("¡Base destruida! GAME OVER.");
        gameObject.SetActive(false);

    }
}

