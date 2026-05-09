using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private PlayerState currentState;
    private CollisionDetector collisions;
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerInput playerInput;
    private PlayerDash playerDash;
    private PlayerCombat playerCombat;
    private PlayerHealth playerHealth;
    private float jumpVelocity = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        collisions = GetComponent<CollisionDetector>();
        playerDash = GetComponent<PlayerDash>();
        playerCombat = GetComponentInChildren<PlayerCombat>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        if (playerHealth != null && playerHealth.IsHit)
            return; // Impede que o movimento normal sobrescreva o knockback de dano
            
        if (playerDash != null && playerDash.IsDashing) 
            return; // Impede que o movimento normal sobrescreva o dash

        float currentSpeed = (playerInput.AimLocked && collisions.IsGrounded) ? 0f : moveSpeed;
        Vector2 newVelocity = new Vector2(playerInput.MoveInput.x * currentSpeed, rb.linearVelocity.y);
        
        if (jumpVelocity > 0)
        {
            newVelocity.y = jumpVelocity;
            jumpVelocity = 0f;
        }

        rb.linearVelocity = newVelocity;
    }
    
    void Update()
    {
        DetermineState();
        switch (currentState)
        {
            case PlayerState.Idle:
                HandleIdle();
                break;
            case PlayerState.Running:
                HandleRunning();
                break;
            case PlayerState.Jumping:
                HandleJumpingState();
                break;
            case PlayerState.Aiming:
                HandleAiming();
                break;
            case PlayerState.Dashing:
                HandleDashing();
                break;
            case PlayerState.Shooting:
                HandleShooting();
                break;
            case PlayerState.RunShooting:
                HandleRunShooting();
                break;
            case PlayerState.Hit:
                HandleHit();
                break;
        }
    }

    void HandleHit()
    {
        // O comportamento de "Hit" e knockback já está a ser processado no PlayerHealth.
        // Apenas evitamos atualizar animações de movimento.
    }

    void HandleIdle()
    {
        HandleJumping();
        UpdateAnimations();
    }

    void HandleRunning()
    {
        FlipSprite();
        HandleJumping();
        UpdateAnimations();
    }

    void HandleJumpingState()
    {
        FlipSprite();
        UpdateAnimations();
    }

    void HandleAiming()
    {
        FlipSprite();
        UpdateAnimations();
    }

    void HandleDashing()
    {
        UpdateAnimations();
    }

    void HandleShooting()
    {
        HandleJumping();
        UpdateAnimations();
    }

    void HandleRunShooting()
    {
        FlipSprite();
        HandleJumping();
        UpdateAnimations();
    }

    void DetermineState()
    {
        bool isShooting = playerCombat != null && playerCombat.IsShooting;

        if (playerHealth != null && playerHealth.IsHit)
            currentState = PlayerState.Hit;
        else if (playerDash != null && playerDash.IsDashing)
            currentState = PlayerState.Dashing;
        else if (playerInput.AimLocked && collisions.IsGrounded)
            currentState = PlayerState.Aiming;
        else if (!collisions.IsGrounded)
            currentState = PlayerState.Jumping;
        else if (Mathf.Abs(playerInput.MoveInput.x) > 0f)
        {
            if (isShooting)
                currentState = PlayerState.RunShooting;
            else
                currentState = PlayerState.Running;
        }
        else
        {
            if (isShooting)
                currentState = PlayerState.Shooting;
            else
                currentState = PlayerState.Idle;
        }
    }
    void HandleJumping()
    {
        if (playerInput.JumpPressed && collisions.IsGrounded && !playerInput.AimLocked)
        {
            jumpVelocity = jumpForce;
        }
        playerInput.UseJump();
    }

    void UpdateAnimations()
    {
        bool isRunning = Mathf.Abs(playerInput.MoveInput.x) > 0f && !(playerInput.AimLocked && collisions.IsGrounded);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", !collisions.IsGrounded);
        anim.SetBool("isAimLocked", playerInput.AimLocked);
    }

    void FlipSprite()
    {
        if (playerInput.MoveInput.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (playerInput.MoveInput.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}