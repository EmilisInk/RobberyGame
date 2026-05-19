using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public bool alarmTriggered = false;
    public Inventory inventory;

    public GameObject guardPrefab;
    public Transform spawnPoint;

    private void Update()
    {
        if (alarmTriggered) return;

        if (inventory.items.Count > 0)
        {
            TriggerAlarm();
        }
    }


    public void TriggerAlarm()
    {
        alarmTriggered = true;
        Debug.Log("Alarm triggered!");

        StartCoroutine(spawnGuard());
        // Here you can add logic to handle the alarm, such as notifying guards, locking doors, etc.
    }

    IEnumerator spawnGuard()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(guardPrefab, spawnPoint.position, spawnPoint.rotation);
        // Instantiate guard prefab at a specific location
        Debug.Log("Guard spawned!");
    }
}
