using UnityEngine;

public class PeaBallet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se colidiu com a layer "Border"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Border"))
        {
            Destroy(gameObject);
        }
    }
}
