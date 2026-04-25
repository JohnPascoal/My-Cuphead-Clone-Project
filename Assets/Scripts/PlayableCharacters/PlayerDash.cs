using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    
    public bool IsDashing { get; private set; }

    private float dashTime;
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerInput playerInput;
    private CollisionDetector collisions;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        collisions = GetComponent<CollisionDetector>();
    }

    void Update()
    {
        if (playerInput.DashPressed && !IsDashing)
        {
            StartDash();
        }

        if (IsDashing)
        {
            dashTime -= Time.deltaTime;

            if (dashTime <= 0)
            {
                StopDash();
            }
        }
    }

    private void FixedUpdate()
    {
        if (IsDashing)
        {
            float direction = transform.localScale.x;
            rb.linearVelocity = new Vector2(direction * dashSpeed, 0f);
        }
    }

    void StartDash()
    {
        IsDashing = true;
        dashTime = dashDuration;

        // Ativa a animação de acordo com o estado no chão ou no ar
        if (collisions.IsGrounded)
        {
            anim.SetBool("isDashingGround", true);
        }
        else
        {
            anim.SetBool("isDashingAir", true);
        }
    }

    void StopDash()
    {
        IsDashing = false;
        anim.SetBool("isDashingGround", false);
        anim.SetBool("isDashingAir", false);
    }
}
