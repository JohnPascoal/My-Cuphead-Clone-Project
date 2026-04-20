using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private PeaBallet peaBalletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenShoots = 0.5f;
    private float shooterCounter = 0;  
    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(peaBalletPrefab, firePoint.position, firePoint.rotation);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            shooterCounter -= Time.deltaTime;
            if (shooterCounter <= 0)
            {
                Instantiate(peaBalletPrefab, firePoint.position, firePoint.rotation);
                shooterCounter = timeBetweenShoots;
            }
        }
    }
}
