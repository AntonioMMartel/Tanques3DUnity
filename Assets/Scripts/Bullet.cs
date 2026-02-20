using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float lifeTime = 5f;

    private Rigidbody rb;

    public GameObject owner;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
       IHittable hittable = other.GetComponent<IHittable>();

        if (hittable != null)
        {
            hittable.Hit(this.gameObject);
        }

    }
}
