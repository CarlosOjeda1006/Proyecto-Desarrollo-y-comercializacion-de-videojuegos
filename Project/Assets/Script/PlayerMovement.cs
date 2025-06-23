using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed += PlayerUpgrades.Instance.velocidadExtra;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;
    }
    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;

        if (movement == Vector2.zero)
            rb.linearVelocity = Vector2.zero;
    }

}


