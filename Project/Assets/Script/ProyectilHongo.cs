using UnityEngine;

public class ProyectilHongo : MonoBehaviour
{
    public float speed = 6f;
    public int damage = 1;

    private Vector2 moveDirection;
    private float timer;
    private int phase = 0;
    private Transform player;

    public void Initialize(Vector2 dir)
    {
        moveDirection = dir.normalized;
        timer = 0f;
        player = GameObject.FindWithTag("Player")?.transform;
        Destroy(gameObject, 7f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (phase == 0 && timer < 2f)
        {
            transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
        }
        else if (phase == 0 && timer >= 2f)
        {
            phase = 1;
            timer = 0f;
        }
        else if (phase == 1 && timer >= 2f)
        {
            if (player != null)
            {
                moveDirection = (player.position - transform.position).normalized;
            }
            phase = 2;
            timer = 0f;
        }
        else if (phase == 2)
        {
            transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null) ph.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

