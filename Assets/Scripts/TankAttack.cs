using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    public void Fire(InputAction.CallbackContext context)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
