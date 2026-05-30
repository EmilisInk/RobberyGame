using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public static Alarm Instance;

    public bool alarmTriggered = false;

    public GameObject guardPrefab;
    public Transform spawnPoint;

    public bool electricityOff = false;

    public AudioSource alarmAudio;

    private void Awake()
    {
        Instance = this;
    }

    public void TriggerFullAlarm(int guardCount)
    {
        if (alarmTriggered) return;

        alarmTriggered = true;

        if (electricityOff)
        {
            StartCoroutine(SpawnGuards(1, 10f));
        }
        else
        {
            StartCoroutine(SpawnGuards(5, 1f));
            alarmAudio.Play();
        }
    }

    public void TriggerDelayedGuards(float delay)
    {
        StartCoroutine(SpawnDelayed(delay));
    }

    IEnumerator SpawnGuards(int count, float delay)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < count; i++)
        {
            Instantiate(guardPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    IEnumerator SpawnDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);

        Instantiate(guardPrefab, spawnPoint.position, spawnPoint.rotation);

        Debug.Log("Delayed guard spawned after " + delay + " seconds.");
    }

    public void SetElectricityOff()
    {
        electricityOff = true;
        Debug.Log("Electricity turned off! Guards will be delayed.");
    }
}
