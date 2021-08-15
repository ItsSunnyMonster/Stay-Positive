// 
// Copyright (c) SunnyMonster
//

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] [Range(0f, .3f)] private float movementSmoothing;
    [SerializeField] private float jumpForce = 700f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [Header("References")]
    [SerializeField] private Transform groundCheck;

    private new Rigidbody2D rigidbody2D;

    private Vector2 velocity;
    private bool onGround;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        onGround = false;

        var colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, ground);
        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                onGround = true;
                break;
            }
        }
    }

    public void Move(float move, bool jump)
    {
        // Calculate the target velocity
        var targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);

        // Smooth the velocity change and set the velocity
        rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

        // If the player should jump
        if (jump && onGround)
        {
            // Jump
            onGround = false;
            rigidbody2D.AddForce(new Vector2(0f, GravitySwitch.instance.gravityIsFlipped ? -jumpForce : jumpForce));
        }
    }
}
