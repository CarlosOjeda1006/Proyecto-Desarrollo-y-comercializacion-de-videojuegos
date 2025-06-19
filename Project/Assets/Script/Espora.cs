using UnityEngine;

public class Espora : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 2f;
    public int maxHealth = 5;
    public int damagePerShot = 1;

    private float fireCooldown;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            ShootInFourDirections();
            fireCooldown = 1f / fireRate;
        }
    }

    void ShootInFourDirections()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        foreach (Vector2 dir in directions)
        {
            GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            EsporaProjectile proj = bullet.GetComponent<EsporaProjectile>();
            if (proj != null)
            {
                proj.Initialize(dir, damagePerShot);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

