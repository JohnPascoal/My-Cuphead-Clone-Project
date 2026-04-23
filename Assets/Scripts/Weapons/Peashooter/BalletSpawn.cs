using UnityEngine;

public class BalletSpawn : MonoBehaviour
{
    [Tooltip("Tempo em segundos antes do objeto ser destruído. Ajuste para bater com o tempo da sua animação.")]
    [SerializeField] private float lifetime = 0.1f;

    void Start()
    {
        // Destrói o gameObject atual após o tempo definido em 'lifetime'
        Destroy(gameObject, lifetime);
    }
}
