using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private CollisionDetector collisions;
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerInput playerInput;
    private float jumpVelocity = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        collisions = GetComponent<CollisionDetector>();
    }

    private void FixedUpdate()
    {
        float currentSpeed = (playerInput.AimLocked && collisions.IsGrounded) ? 0f : moveSpeed;
        Vector2 newVelocity = new Vector2(playerInput.Horizontal * currentSpeed, rb.linearVelocity.y);
        
        if (jumpVelocity > 0)
        {
            newVelocity.y = jumpVelocity;
            jumpVelocity = 0f;
        }

        rb.linearVelocity = newVelocity;
    }
    
    void Update()
    {
        FlipSprite();
        HandleJumping();
        UpdateAnimations();
    }

    void HandleJumping()
    {
        if (playerInput.JumpPressed && collisions.IsGrounded && !playerInput.AimLocked)
        {
            jumpVelocity = jumpForce;
        }
    }

    void UpdateAnimations()
    {
        bool isRunning = Mathf.Abs(playerInput.Horizontal) > 0f && !(playerInput.AimLocked && collisions.IsGrounded);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", !collisions.IsGrounded);
        anim.SetBool("isAimLocked", playerInput.AimLocked);
    }

    void FlipSprite()
    {
        if (playerInput.Horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (playerInput.Horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}