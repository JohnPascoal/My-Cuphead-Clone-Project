using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private PeaBallet peaBalletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(peaBalletPrefab, transform.position, transform.rotation);
            Debug.Log("Shoot");
        }
    }
}
