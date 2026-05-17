using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float range = 3f;
    public Camera cam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.Log("Hit: " + hit.collider.name);
                
                WorldItem worldItem = hit.collider.GetComponent<WorldItem>();

                if (worldItem != null)
                {
                    Inventory inventory = GetComponent<Inventory>();

                    inventory.AddItem(worldItem.itemData, 1);

                    Debug.Log("Picked up: " + worldItem.itemData.itemName);

                    Destroy(worldItem.gameObject);
                }
            }
        }
    }
}
