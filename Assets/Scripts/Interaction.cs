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
                //Interactable interactable = hit.collider.GetComponent<Interactable>();
                //if (interactable != null)
                //{
                //    interactable.Interact();
                //}
            }
        }
    }
}
