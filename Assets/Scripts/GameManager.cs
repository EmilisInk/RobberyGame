using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalMoney;

    [Header("Items")]
    public bool hasArmor;
    public bool hasLockPick;
    public bool hasJammer;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int amount)
    {
        totalMoney += amount;
        Debug.Log("Total Money: " + totalMoney);
    }
}
