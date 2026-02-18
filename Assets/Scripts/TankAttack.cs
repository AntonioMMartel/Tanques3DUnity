using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 2f; 
    private bool isFiring = false;
    private float fireTimer = 0f;

    private void Update()
    {
        if (isFiring)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= 1f / fireRate)
            {
                Shoot();
                fireTimer = 0f;
            }
        }
    }
    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)   // Mouse button pressed
            isFiring = true;

        if (context.canceled)  // Mouse button released
            isFiring = false;
    }
    
    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
