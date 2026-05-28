using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUI : MonoBehaviour
{
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
