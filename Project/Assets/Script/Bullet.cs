using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ShooterEnemy shooter = other.GetComponent<ShooterEnemy>();
            if (shooter != null)
            {
                shooter.TakeDamage(damage);
            }

            EnemyAI melee = other.GetComponent<EnemyAI>();
            if (melee != null)
            {
                melee.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}


