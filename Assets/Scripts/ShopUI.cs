using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject ShopPanel;
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        ShopPanel.SetActive(false);
        UpdateMoney();
    }

    public void ToggleShop()
    {
        ShopPanel.SetActive(!ShopPanel.activeSelf);
        UpdateMoney();
    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }

    public void BuyArmor()
    {
        int cost = 1500;

        if(GameManager.Instance.totalMoney >= cost)
        {
            GameManager.Instance.totalMoney -= cost;
            GameManager.Instance.hasArmor = true;
            UpdateMoney();
            Debug.Log("Armor purchased!");
        }
        else
        {
            Debug.Log("Not enough money to buy armor.");
        }
    }

    public void BuyJammer()
    {
        int cost = 25000;

        if (GameManager.Instance.totalMoney >= cost)
        {
            GameManager.Instance.totalMoney -= cost;
            GameManager.Instance.hasJammer = true;
            UpdateMoney();
            Debug.Log("Jammer purchased!");
        }
        else
        {
            Debug.Log("Not enough money to buy jammer.");
        }
    }

    public void BuyLockPick()
    {
        int cost = 500;

        if (GameManager.Instance.totalMoney >= cost)
        {
            GameManager.Instance.totalMoney -= cost;
            GameManager.Instance.hasLockPick = true;
            UpdateMoney();
            Debug.Log("LockPick purchased!");
        }
        else
        {
            Debug.Log("Not enough money to buy lockpick.");
        }
    }

    public void UpdateMoney()
    {
        moneyText.text = $"${GameManager.Instance.totalMoney}";
    }


}
