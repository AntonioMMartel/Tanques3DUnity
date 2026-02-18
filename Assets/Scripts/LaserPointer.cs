using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float maxDistance = 20f;
    [SerializeField] int maxBounces = 1;
    [SerializeField] LayerMask wallMask;


    void Start()
    {
        if (!lineRenderer)
            lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        DrawLaser();
    }

    void DrawLaser()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, origin);

        int bounceCount = 0;
        
        while (bounceCount < maxBounces)
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance, wallMask))
            {
                // Add the hit point to the line
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

                // Reflect the direction
                direction = Vector3.Reflect(direction, hit.normal);

                // Move origin slightly past collision to avoid hitting the same wall
                origin = hit.point + direction * 0.01f;

                bounceCount++;
            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, origin + direction * maxDistance);
                break;
            }
        }
    }
}
