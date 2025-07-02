using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    void Start()
    {
        currentHealth = maxHealth + PlayerUpgrades.Instance.vidaExtra;
        maxHealth = currentHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Jugador curado. Vida actual: " + currentHealth);
    }
    void Die()
    {
        Debug.Log("Player died!");
        gameObject.SetActive(false);
        Object.FindFirstObjectByType<EndGameUI>().ShowDefeat();
    }

}


