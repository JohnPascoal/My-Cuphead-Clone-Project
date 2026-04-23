using UnityEngine;

public class PeaBallet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject balletDeath;

    void Start()
    {
    }

    void Update()
    {
        // Movimentação constante e independente.
        // Como o projétil já nasce com a rotação certa no Shooting.cs, andar pra "frente" (right) sempre vai na direção certa.
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se colidiu com a layer "Border"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Border"))
        {
            Instantiate(balletDeath, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
