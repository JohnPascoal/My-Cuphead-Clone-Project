using UnityEngine;

public class CupheadMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.1f;
    
    private bool isGrounded;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Collider2D coll;
    private float jumpVelocity = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        // Apply movement horizontally and maintain current vertical velocity (gravity)
        Vector2 newVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
        
        // Apply jump velocity if it was triggered
        if (jumpVelocity > 0)
        {
            newVelocity.y = jumpVelocity;
            jumpVelocity = 0f;
        }

        rb.linearVelocity = newVelocity;
    }
    
    void Update()
    {
        // Get input from the player
        movement.x = Input.GetAxisRaw("Horizontal");
        
        CheckGrounded();
        FlipSprite();
        Jumping();
    }

    void FlipSprite()
    {
        if (movement.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movement.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jumping()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpVelocity = jumpForce;
            Debug.Log($"Jump applied! Force: {jumpForce}");
        }
    }

    void CheckGrounded()
    {
        // Cast a ray downward from the bottom of the collider to check for ground
        Vector2 rayOrigin = coll.bounds.center;
        rayOrigin.y = coll.bounds.min.y;
        
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null;
        
        // Debug visualization (optional, remove for production)
        Debug.DrawRay(rayOrigin, Vector2.down * groundCheckDistance, isGrounded ? Color.green : Color.red);
    }
}
