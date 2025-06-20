using UnityEngine;

public class RatonCapitan : MonoBehaviour
{
    public float speed = 2f;
    public int maxHealth = 20;
    public float fireRate = 1f;
    public float meleeRange = 2f;
    public float shootRange = 6f;
    public int meleeDamage = 3;
    public int shootDamage = 1;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform player;

    private float currentHealth;
    private float fireCooldown;
    private float meleeCooldown = 1f;
    private float meleeTimer;

    void Start()
    {
        currentHealth = maxHealth;

        if (player == null)
            player = GameObject.FindWithTag("Player")?.transform;
    }


    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        Vector2 direction = (player.position - transform.position).normalized;

        if (distance <= meleeRange)
        {
            transform.position += (Vector3)direction * speed * Time.deltaTime;
            meleeTimer -= Time.deltaTime;
            if (meleeTimer <= 0f)
            {
                PlayerHealth ph = player.GetComponent<PlayerHealth>();
                if (ph != null) ph.TakeDamage(meleeDamage);
                meleeTimer = meleeCooldown;
            }
        }
        else if (distance <= shootRange)
        {
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0f)
            {
                ShootAtPlayer();
                fireCooldown = 1f / fireRate;
            }
        }
        else
        {
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    void ShootAtPlayer()
    {
        if (projectilePrefab == null || firePoint == null || player == null) return;

        Vector2 dir = (player.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile proj = bullet.GetComponent<Projectile>();
        if (proj != null)
        {
            proj.Initialize(dir, "Player", shootDamage);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            TryDropCoin(1f);
            Destroy(gameObject);
        }
    }

    public void TryDropCoin(float dropChance)
    {
        float roll = Random.Range(0f, 1f);
        if (roll <= dropChance)
        {
            GameObject coin = Instantiate(Resources.Load<GameObject>("Coin"), transform.position, Quaternion.identity);
        }
    }

}

