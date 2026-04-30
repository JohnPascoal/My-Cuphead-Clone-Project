using System.Collections;
using UnityEngine;

public class SalSpudderAttack : MonoBehaviour
{
    [Header("Atributos do Boss")]
    [SerializeField] private int health = 100;
    [SerializeField] private float deathDelay = 3f;

    [Header("Configurações de Ataque")]
    [SerializeField] private GameObject projetilPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int projectilesPerAttack = 3;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float idleDuration = 2f;

    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (!isDead)
        {
            // Estado Idle (Parado)
            anim.SetBool("IsAttacking", false);
            yield return new WaitForSeconds(idleDuration);

            if (isDead) break;

            // Estado de Ataque
            anim.SetBool("IsAttacking", true);
            
            // Dispara múltiplos projéteis
            for (int i = 0; i < projectilesPerAttack; i++)
            {
                if (isDead) break;
                
                //Shoot();
                yield return new WaitForSeconds(fireRate);
            }
        }
    }

    void Shoot()
    {
        if (projetilPrefab != null && firePoint != null)
        {
            Instantiate(projetilPrefab, firePoint.position, firePoint.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        // Verifica colisão com o tiro do player (PeaBallet)
        if (collision.GetComponent<PeaBallet>() != null)
        {
            TakeDamage(5); // Define o dano que cada PeaBallet causa
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        StopAllCoroutines();
        
        if (anim != null)
        {
            anim.SetBool("IsAttacking", false);
            anim.SetTrigger("Death");
        }
        
        // Desativar colisor para não receber mais danos após a morte, se necessário
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        // Destrói o objeto após alguns segundos para a animação terminar
        Destroy(gameObject, deathDelay);
    }
}
