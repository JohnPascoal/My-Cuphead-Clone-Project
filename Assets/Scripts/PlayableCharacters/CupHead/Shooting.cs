using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private KeyCode shootKey = KeyCode.R;
    [SerializeField] private PeaBallet peaBalletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenShoots = 0.5f;
    private float shooterCounter = 0;
    [SerializeField] private Animator anim;

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponentInParent<Animator>();
        }
    }

    void Update()
    {
        bool isShooting = Input.GetKey(shootKey);
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (anim != null)
        {
            anim.SetBool("isShooting", isShooting);

            // Pegar a direção que o player está virado
            float facingDirection = Mathf.Sign(transform.lossyScale.x); // 1 = direita, -1 = esquerda

            float aimX, aimY;

            if (inputX == 0f && inputY == 0f)
            {
                // Sem direcional: atirar para a frente (relativo ao facing)
                aimX = 1f; // Blend Tree sempre usa valores positivos de X
                aimY = 0f;
            }
            else
            {
                // Converter o input para espaço LOCAL do player
                // Se virado para esquerda, inputX negativo vira "frente" = positivo na Blend Tree
                float localX = inputX * facingDirection;
                aimX = Mathf.Abs(localX) > 0.1f ? 1f : 0f;
                aimY = inputY > 0.1f ? 1f : (inputY < -0.1f ? -1f : 0f);
            }

            anim.SetFloat("AimX", aimX);
            anim.SetFloat("AimY", aimY);

            // Força o Animator a atualizar os transforms imediatamente neste frame.
            // Isso garante que o firePoint esteja na posição correta da animação antes do primeiro tiro despachar.
            anim.Update(0f);
        }

        if (Input.GetKeyDown(shootKey))
        {
            ShootProjectile(inputX, inputY);
        }
        if (Input.GetKey(shootKey))
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
