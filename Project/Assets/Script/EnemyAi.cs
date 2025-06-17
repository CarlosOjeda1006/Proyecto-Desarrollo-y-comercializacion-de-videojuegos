using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float detectionRange = 10f;
    public int maxHealth = 3;

    private int currentHealth;
    private Rigidbody2D rb;
    private bool isTouchingPlayer = false;
    private Coroutine damageCoroutine;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null || isTouchingPlayer)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = true;

            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(DealDamageOverTime(collision.gameObject));
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;

            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    IEnumerator DealDamageOverTime(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        while (true)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
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



