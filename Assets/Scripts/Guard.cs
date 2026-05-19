using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    public float stopDistance = 4f;

    public float shootRange = 10f;
    public float damage = 10f;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootCooldown = 1f;

    private float lastShootTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
    }


    void Update()
    {
        if(player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if(distance > stopDistance)
        {
            agent.isStopped = false;

            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;

            Shoot();
        }
    }

    void Shoot()
    {
        if(Time.time < lastShootTime + shootCooldown) return;

        lastShootTime = Time.time;

        Vector3 origin = shootPoint.position;
        Vector3 dir = (player.position + Vector3.up - origin).normalized;

        Ray ray = new Ray(origin, dir);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, shootRange))
        {
            PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
            if(playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Player hit! Remaining health: " + playerHealth.currentHealth);
            }
        }

        //Debug.DrawRay(origin, dir * shootRange, Color.red, 1f);
    }
}
