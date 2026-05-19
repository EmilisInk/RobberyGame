using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;
    public float lifetime = 3f;

    private Vector3 direction;

    public void Init(Vector3 direction)
    {
        direction = direction.normalized;
    }
    private void Start()
    {
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
            player.TakeDamage(10f);
            Destroy(gameObject);
            return;
        }

        if(!other.isTrigger)
        {
            Destroy(gameObject);
        }


    }


}
