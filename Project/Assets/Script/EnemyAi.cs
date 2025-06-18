using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    public Transform baseTransform;
    public float speed = 2f;
    public float detectionRange = 10f;
    public int maxHealth = 3;

    private int currentHealth;
    private Rigidbody2D rb;
    private Transform playerTransform;
    private bool isTouchingTarget = false;
    private Coroutine damageCoroutine;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
        if (isTouchingTarget)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Transform target = GetClosestTarget();
        if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.position);
            if (distance <= detectionRange)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                rb.linearVelocity = direction * speed;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    Transform GetClosestTarget()
    {
        if (playerTransform == null || baseTransform == null)
            return null;

        float distToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        float distToBase = Vector2.Distance(transform.position, baseTransform.position);

        return (distToPlayer <= distToBase) ? playerTransform : baseTransform;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Base"))
        {
            isTouchingTarget = true;

            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(DealDamageOverTime(collision.gameObject));
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Base"))
        {
            isTouchingTarget = false;

            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    IEnumerator DealDamageOverTime(GameObject target)
    {
        while (true)
        {
            if (target == null)
            {
                damageCoroutine = null;
                yield break;
            }

            if (target.CompareTag("Player"))
            {
                PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1);
                }
            }
            else if (target.CompareTag("Base"))
            {
                BaseHealth baseHealth = target.GetComponent<BaseHealth>();
                if (baseHealth != null)
                {
                    baseHealth.TakeDamage(1);
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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



