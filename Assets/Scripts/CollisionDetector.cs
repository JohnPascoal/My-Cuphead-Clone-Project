using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.1f;
    
    private Collider2D coll;
    public bool IsGrounded { get; private set; }

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        Vector2 rayOrigin = coll.bounds.center;
        rayOrigin.y = coll.bounds.min.y;
        
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        IsGrounded = hit.collider != null;
        
        // Visualização no Editor para facilitar o seu debug
        Debug.DrawRay(rayOrigin, Vector2.down * groundCheckDistance, IsGrounded ? Color.green : Color.red);
    }
}