using UnityEngine;

public class PeaBallet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
