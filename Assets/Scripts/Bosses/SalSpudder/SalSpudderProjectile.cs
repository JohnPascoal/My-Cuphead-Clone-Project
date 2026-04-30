using UnityEngine;

public class SalSpudderProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Border"))
        {
            Destroy(gameObject, 2f);
        }
    }
}