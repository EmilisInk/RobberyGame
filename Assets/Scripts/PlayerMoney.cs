using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int money;

    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Money added: " + amount + ". Total money: " + money);
    }
}
