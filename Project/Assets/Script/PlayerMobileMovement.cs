using UnityEngine;

public class PlayerMobileMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public TouchJoystick joystick;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 input = joystick.InputDirection;
        rb.linearVelocity = input * moveSpeed;
    }
}







