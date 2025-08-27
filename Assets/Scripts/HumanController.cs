using UnityEngine;
using UnityEngine.InputSystem; // New input system

public class HumanController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float move;     // -1,0,1
    private bool wantJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // --- New input system reads keyboard ---
        move = 0f;
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)  move -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) move += 1f;

        if ((Keyboard.current.spaceKey.wasPressedThisFrame) && isGrounded)
            wantJump = true;

        // Flip direction
        if (move > 0) sr.flipX = false;
        else if (move < 0) sr.flipX = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        if (wantJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            wantJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) isGrounded = false;
    }
}