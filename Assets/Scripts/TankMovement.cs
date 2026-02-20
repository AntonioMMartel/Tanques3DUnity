using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 5f;

    [Header("Base (Visual2)")]
    [SerializeField] Transform baseVisual;
    [SerializeField] float baseTurnSpeed = 12f;

    Vector2 movementInput;

    void FixedUpdate()
    {
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y) * moveSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        RotateBaseTowardMovement(move);
    }

    void RotateBaseTowardMovement(Vector3 move)
    {
        Vector3 planar = new Vector3(move.x, 0f, move.z);
        if (planar.sqrMagnitude < 0.001f) return;

        Quaternion targetRot = Quaternion.LookRotation(planar.normalized);
        baseVisual.rotation = Quaternion.Slerp(
            baseVisual.rotation,
            targetRot,
            baseTurnSpeed * Time.fixedDeltaTime
        );
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
