using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private void Start()
    {
        moneyText.text = "$" + GameManager.Instance.totalMoney;
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void Shop()
    {
        Debug.Log("Shop");
    }

    public void Loadout()
    {
        Debug.Log("Loadout");
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }
}
