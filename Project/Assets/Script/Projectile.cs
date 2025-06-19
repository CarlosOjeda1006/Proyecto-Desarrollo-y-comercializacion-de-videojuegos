using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 moveDirection;
    private string targetTag;
    private int damage;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void Initialize(Vector2 direction, string tag, int dmg)
    {
        moveDirection = direction.normalized;
        targetTag = tag;
        damage = dmg;
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            if (targetTag == "Player")
            {
                PlayerHealth ph = other.GetComponent<PlayerHealth>();
                if (ph != null) ph.TakeDamage(damage);
            }
            else if (targetTag == "Base")
            {
                BaseHealth bh = other.GetComponent<BaseHealth>();
                if (bh != null) bh.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}



