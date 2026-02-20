using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankAim : MonoBehaviour
{
    Camera cam;

    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] Transform turretVisual;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        AimTowardMouse();
    }

    void AimTowardMouse()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = cam.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPoint = hit.point;
            targetPoint.y = turretVisual.position.y;

            Vector3 direction = targetPoint - turretVisual.position;

            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                turretVisual.rotation = Quaternion.Slerp(
                    turretVisual.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }
    }
}