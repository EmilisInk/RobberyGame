using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int money;

    public void AddMoney(int amount)
    {
        money += amount;
    }
}
