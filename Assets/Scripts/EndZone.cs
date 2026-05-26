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
            // Trigger end game sequence
            Debug.Log("Player has reached the end zone and pressed E. Ending game...");
            // You can add your end game logic here, such as loading a new scene or showing a victory screen.
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
        Debug.Log("Game Finished! Implement your end game logic here.");

        SceneManager.LoadScene("Lobby");
    }
}
