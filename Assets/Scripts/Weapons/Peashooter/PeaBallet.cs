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
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Instantiate(balletDeath, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Border"))
        {
            //Instantiate(balletDeath, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
