using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public bool isUsed = false;

    public AudioSource electricityAudio;

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.E) && !isUsed)
        {
            isUsed = true;
            electricityAudio.Play();
            TurnOffElectricity();
        }
    }

    void TurnOffElectricity()
    {

        Alarm.Instance.SetElectricityOff();
    }
}
