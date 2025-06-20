using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;
    public int maxHealth = 5;
    public int damage = 1;
    public float attackCooldown = 1f;

    public Transform player;
    public Transform baseTarget;

    private float currentHealth;
    private float attackTimer;

    void Start()
    {
        currentHealth = maxHealth;

        if (player == null)
            player = GameObject.FindWithTag("Player")?.transform;

        if (baseTarget == null)
            baseTarget = GameObject.FindWithTag("Base")?.transform;
    }

    void Update()
    {
        Transform target = GetClosestTarget();
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > 0.5f)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }
        else
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                if (target.CompareTag("Player"))
                {
                    PlayerHealth ph = target.GetComponent<PlayerHealth>();
                    if (ph != null) ph.TakeDamage(damage);
                }
                else if (target.CompareTag("Base"))
                {
                    BaseHealth bh = target.GetComponent<BaseHealth>();
                    if (bh != null) bh.TakeDamage(damage);
                }

                attackTimer = attackCooldown;
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

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            TryDropCoin(0.75f);
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




