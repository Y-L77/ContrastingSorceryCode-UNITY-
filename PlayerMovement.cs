using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;               // Speed of horizontal movement
    public float jumpPower = 8f;           // Force of the jump
    public Transform groundCheck;          // Transform representing where to check if grounded
    public float groundCheckRadius = 0.2f; // Radius of the circle to check if grounded
    public LayerMask groundLayer;          // Layer mask for the ground
    public LayerMask ladderLayer;          // Layer mask for the ladder
    public bool facingRight = true;        // Flag to track which direction the player is facing

    private Rigidbody2D rb;                // Reference to the Rigidbody2D component
    private bool isGrounded;               // Flag to check if the player is grounded
    private bool isTouchingLadder;         // Flag to check if the player is touching a ladder

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if grounded using Physics2D.OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Flip sprite if moving in different direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // Jumping
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        // Ladder climbing
        if (isTouchingLadder)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ladder"))
        {
            isTouchingLadder = true;
            rb.gravityScale = 0; // Disable gravity while on ladder
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ladder"))
        {
            isTouchingLadder = false;
            rb.gravityScale = 1.5f; // Enable gravity when leaving the ladder
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
