using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private KeyCode shootKey = KeyCode.R;
    [SerializeField] private PeaBallet peaBalletPrefab;
    [SerializeField] private GameObject balletSpawnPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenShoots = 0.5f;
    private float shooterCounter = 0;
    [SerializeField] private Animator anim;
    private PlayerDash playerDash;

    public bool IsShooting { get; private set; }

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponentInParent<Animator>();
        }
        playerDash = GetComponentInParent<PlayerDash>();
    }

    void Update()
    {
        IsShooting = Input.GetKey(shootKey);

        if (playerDash != null && playerDash.IsDashing)
        {
            IsShooting = false; // no estado dash não pode disparar
        }

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (anim != null)
        {
            if (anim.GetBool("isRunning") && inputY < 0)
            {
                inputY = 0f;
            }

            anim.SetBool("isShooting", IsShooting);

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

        if (!IsShooting && !Input.GetKeyDown(shootKey)) return;

        if (Input.GetKeyDown(shootKey) && !(playerDash != null && playerDash.IsDashing))
        {
            ShootProjectile(inputX, inputY);
        }
        if (IsShooting)
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
        float facingDirection = Mathf.Sign(transform.lossyScale.x);
        if (x == 0 && y == 0)
        {
            x = facingDirection;
        }

        // Calcula a direção em vetor para a mira
        Vector2 shootDir = new Vector2(x, y).normalized;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = Quaternion.Euler(0, 0, angle);

        Instantiate(peaBalletPrefab, firePoint.position, bulletRotation);
        if (balletSpawnPrefab != null)
        {
            Instantiate(balletSpawnPrefab, spawnPoint.position, bulletRotation);
        }
    }
}
