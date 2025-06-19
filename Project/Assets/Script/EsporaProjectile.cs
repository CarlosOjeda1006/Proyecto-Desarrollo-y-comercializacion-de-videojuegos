using UnityEngine;

public class EsporaProjectile : MonoBehaviour
{
    public float speed = 6f;
    private Vector2 direction;
    private int damage;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void Initialize(Vector2 dir, int dmg)
    {
        direction = dir.normalized;
        damage = dmg;
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null) ph.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Base"))
        {
            BaseHealth bh = other.GetComponent<BaseHealth>();
            if (bh != null) bh.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}


