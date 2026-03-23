using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 input;
    private Animator anim;
    private Vector2 lastMoveDirection;
    private bool faceinfLeft = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();
        Animate();
        if (input.x < 0 && !faceinfLeft || input.x > 0 && faceinfLeft)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX == 0 && moveY == 0 && (input.x != 0 || input.y != 0))
        {
            lastMoveDirection = input;
        }
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
    }

    void Animate()
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
        anim.SetFloat("MoveMagnitude", input.magnitude);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        faceinfLeft = !faceinfLeft;
    }
}
