using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Referências")]
    public GameObject player;
    private CupheadMovement movementScript;
    private Shooting shootingScript;

    void Awake()
    {
        movementScript = player.GetComponent<CupheadMovement>();
        shootingScript = player.GetComponentInChildren<Shooting>();
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }
        if (shootingScript != null)
        {
            shootingScript.enabled = false;
        }
    }
    void Start()
    {
        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        // 1. Um pequeno atraso inicial para dispositivos lentos processarem os primeiros frames
        yield return new WaitForSeconds(0.5f);

        movementScript.enabled = false;
        shootingScript.enabled = false;
        Debug.Log("Estado: Introdução - Player Travado");

        // 2. Esperar pelo menos 1 frame antes de checar o Animator, garantindo que a animação inicial já foi carregada
        yield return null;

        // 3. Agora é seguro ler a duração da animação
        float introDuration = player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

        // 4. Esperar o tempo da animação terminar
        yield return new WaitForSeconds(introDuration - 0.5f); // Subtraia um pequeno tempo para garantir que a transição seja suave

        movementScript.enabled = true;
        shootingScript.enabled = true;
        player.GetComponent<Animator>().SetTrigger("StartGameplay");
        Debug.Log("Estado: Gameplay - Player Liberado");
    }

    void Update()
    {

    }
}
