using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    [Header("Combat")]
    public float shootRange = 10f;
    public float shootCooldown = 1f;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform shootPoint;

    [Header("Audio")]
    public AudioSource shootSound;

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

        if(distance > shootRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;

            LookAtPlayer();

            Shoot();
        }
    }

    void LookAtPlayer()
    {
        Vector3 lookPos = player.position - transform.position;
        lookPos.y = 0;

        transform.rotation = Quaternion.LookRotation(lookPos);
    }

    void Shoot()
    {
        if(Time.time < lastShootTime + shootCooldown) return;

        Vector3 origin = shootPoint.position;
        Vector3 target = player.position + Vector3.up;

        Vector3 dir = (target - origin).normalized;

        RaycastHit hit;

        if(Physics.Raycast(origin, dir, out hit, shootRange))
        {
            if(!hit.collider.CompareTag("Player")) return;
        }
        else
        {
            return;
        }

        lastShootTime = Time.time;

        shootSound.Play();

        GameObject bullet = Instantiate(bulletPrefab, origin, Quaternion.LookRotation(dir));

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.Init(dir);

    }
}
