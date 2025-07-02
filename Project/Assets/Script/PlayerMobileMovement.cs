using UnityEngine;

public class PlayerMobileMovement : MonoBehaviour
{
    public float baseMoveSpeed = 5f;
    public TouchJoystick joystick;
    private Rigidbody2D rb;
    private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = baseMoveSpeed + PlayerUpgrades.Instance.velocidadExtra;
    }

    void FixedUpdate()
    {
        Vector2 input = joystick.InputDirection;
        rb.linearVelocity = input * moveSpeed;
    }
}








