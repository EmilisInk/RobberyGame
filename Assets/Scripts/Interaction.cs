using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float range = 3f;
    public Camera cam;

    public AudioSource pickupAudio;

    private PlayerMoney money;

    private void Start()
    {
        money = GetComponent<PlayerMoney>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, range))
            {
                WorldItem worldItem = hit.collider.GetComponent<WorldItem>();

                if (worldItem != null)
                {
                    money.AddMoney(worldItem.itemData.value);

                    pickupAudio.Play();

                    Debug.Log("Picked up " + worldItem.itemData.name + " worth " + worldItem.itemData.value + " money.");

                    Alarm.Instance.TriggerFullAlarm(5);

                    Destroy(worldItem.gameObject);
                }
            }
        }
    }
}
