using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 2f;
    public int maxHealth = 5;
    public float fireRate = 2f;
    public float shootingRange = 5f;
    public int damagePerShot = 1;

    [Header("Targeting")]
    public Transform player;
    public Transform baseTarget;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private float currentHealth;
    private float fireCooldown;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Transform target = GetClosestTarget();
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > shootingRange)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
        else
        {
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0f)
            {
                Shoot(target);
                fireCooldown = 1f / fireRate;
            }
        }
    }

    Transform GetClosestTarget()
    {
        if (player == null || baseTarget == null) return null;

        float playerDist = Vector2.Distance(transform.position, player.position);
        float baseDist = Vector2.Distance(transform.position, baseTarget.position);

        return playerDist <= baseDist ? player : baseTarget;
    }

    void Shoot(Transform target)
    {
        if (projectilePrefab == null || firePoint == null || target == null) return;

        Vector2 direction = (target.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile proj = bullet.GetComponent<Projectile>();

        if (proj != null)
        {
            string targetTag = target.CompareTag("Player") ? "Player" : "Base";
            proj.Initialize(direction, targetTag, damagePerShot);
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

