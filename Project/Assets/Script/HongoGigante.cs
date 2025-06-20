using UnityEngine;

public class HongoGigante : MonoBehaviour
{
    public int maxHealth = 30;
    public float fireRate = 3f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private float currentHealth;
    private float fireCooldown;
    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null || projectilePrefab == null || firePoint == null) return;

        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            Vector2 direction = (player.position - firePoint.position).normalized;
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            ProyectilHongo p = proj.GetComponent<ProyectilHongo>();
            if (p != null)
            {
                p.Initialize(direction);
            }
            fireCooldown = 1f / fireRate;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Destroy(gameObject);
    }
}

