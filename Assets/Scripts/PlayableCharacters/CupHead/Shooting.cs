using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private PeaBallet peaBalletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenShoots = 0.5f;
    private float shooterCounter = 0;  
    [SerializeField] private Animator anim;
    
    void Start()
    {
        /*if (anim == null)
            anim = GetComponent<Animator>();
        
        if (anim == null)*/
            anim = GetComponentInParent<Animator>();
    }
    
    void Update()
    {
        bool isShooting = Input.GetKey(KeyCode.X);
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (anim != null)
        {
            anim.SetBool("isShooting", isShooting);
            
            // Lógica para enviar os valores corretos para o Blend Tree
            float aimX = Mathf.Abs(inputX);
            float aimY = inputY;

            // Se o jogador estiver apenas atirando parado (sem pressionar as setas), 
            // forçamos o AimX a ser 1 para ele tocar a animação "CupheadStraightShoot" (X=1, Y=0).
            if (aimX == 0 && aimY == 0)
            {
                aimX = 1f;
            }

            anim.SetFloat("AimX", aimX); 
            anim.SetFloat("AimY", aimY);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootProjectile(inputX, inputY);
        }
        if (Input.GetKey(KeyCode.X))
        {
            shooterCounter -= Time.deltaTime;
            if (shooterCounter <= 0)
            {
                ShootProjectile(inputX, inputY);
                shooterCounter = timeBetweenShoots;
            }
        }
    }

    private void ShootProjectile(float x, float y)
    {
        // Se o player está virado usando scale X negativo, pegamos a direção global correta.
        float facingDirection = Mathf.Sign(transform.lossyScale.x);

        // Se não tivermos nenhum direcional pressionado (x=0, y=0), atira para onde está virado
        if (x == 0 && y == 0)
        {
            x = facingDirection;
        }

        // Calcula a direção em vetor para a mira
        Vector2 shootDir = new Vector2(x, y).normalized;

        // O segredo aqui é NÃO mexer no "firePoint.rotation".
        // Como o player roda virando a escala X em negativo no CupheadMovement,
        // mudar a rotação de um objeto filho (firepoint) vai causar bugs de matriz na Unity.
        // Em vez disso, nós passamos o ângulo direto para a bala nascer virada.
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = Quaternion.Euler(0, 0, angle);

        Instantiate(peaBalletPrefab, firePoint.position, bulletRotation);
    }
}
