using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    public bool playerInside = false;

    private void Update()
    {
        if (!playerInside) return;

        if(Input.GetKeyDown(KeyCode.E))
        {
            FinishGame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void FinishGame()
    {
        PlayerMoney playerMoney = FindObjectOfType<PlayerMoney>();

        if (playerMoney != null)
        {
            GameManager.Instance.totalMoney += playerMoney.money;

            //Debug.Log($"Player's money added to total. Total money: {GameManager.Instance.totalMoney}");
        }

        SceneManager.LoadScene("Lobby");

    }
}
