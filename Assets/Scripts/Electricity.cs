using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public bool isUsed = false;

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.E) && !isUsed)
        {
            isUsed = true;
            Debug.Log("Electricity used!");
            TurnOffElectricity();
        }
    }

    void TurnOffElectricity()
    {
        Debug.Log("Electricity turned off!");

        Alarm.Instance.SetElectricityOff();
    }
}
