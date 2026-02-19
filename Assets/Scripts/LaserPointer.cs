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
                // Añade el punto de impacto con la pared al muro
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

                // Reflejar rayo usando normal de punto de impacto al muro
                direction = Vector3.Reflect(direction, hit.normal);

                // Prevenir otra colosión con el muro
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
