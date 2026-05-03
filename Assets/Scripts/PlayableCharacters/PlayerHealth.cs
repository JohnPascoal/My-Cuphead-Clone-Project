using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float invulnerabilityDuration = 1.5f;
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private Vector2 knockbackDirection = new Vector2(1, 1);

    private int currentHealth;
    private bool isInvulnerable = false;
    private Animator anim;
    private Rigidbody2D rb;

    public bool IsHit { get; private set; }

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")
        || collision.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            TakeDamage(collision.transform.position);
            //Destroy(collision.gameObject);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")
        || collision.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            TakeDamage(collision.transform.position);
        }
    }*/

    private void TakeDamage(Vector3 damageSourcePosition)
    {
        if (isInvulnerable || IsHit) return;

        currentHealth--;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(DamageRoutine(damageSourcePosition));
        }
    }

    private IEnumerator DamageRoutine(Vector3 damageSourcePosition)
    {
        IsHit = true;
        isInvulnerable = true;
        anim.SetTrigger("Hit");
        // Calculate knockback direction based on source position
        float direction = transform.position.x < damageSourcePosition.x ? 1f : -1f;
        // Reset current velocity
        rb.linearVelocity = Vector2.zero;
        // Apply knockback
        rb.AddForce(new Vector2(knockbackDirection.x * direction, knockbackDirection.y).normalized * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        IsHit = false;
        yield return new WaitForSeconds(invulnerabilityDuration - 0.4f);
        isInvulnerable = false;
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        Debug.Log("Player Died!");
        IsHit = true;
    }
}
