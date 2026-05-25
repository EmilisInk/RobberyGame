using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;
    public float lifetime = 3f;
    public float damage = 10f;

    private Vector3 direction;

    private Rigidbody rb;

    public void Init(Vector3 dir)
    {
        direction = dir.normalized;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = direction * speed;

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }

        if(!other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
