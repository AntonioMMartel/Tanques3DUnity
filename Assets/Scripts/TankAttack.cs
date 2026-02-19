using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 2f; 
    private bool isFiring = false;
    private float fireTimer = 0f;

    [SerializeField] int maxAmmo = 30;
    [SerializeField] TMP_Text ammoText;

    private int currentAmmo;
    private void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    private void Update()
    {
        if (isFiring)
        {
            if (currentAmmo <= 0)
            {
                isFiring = false;
                return;
            }

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

    private void UpdateAmmoUI()
    {
        if (ammoText != null)
            ammoText.text = $"Ammo: {currentAmmo}/{maxAmmo}";
    }

    private void Shoot()
    {
        if (currentAmmo <= 0) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().owner = this.gameObject;

        currentAmmo--;
        UpdateAmmoUI();
    }


    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
        UpdateAmmoUI();
    }

}
