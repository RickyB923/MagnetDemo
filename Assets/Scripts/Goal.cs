using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utilities;

public class Goal : MonoBehaviour
{
    // This script is for managing the win condition of the Platformer scene
    [SerializeField] GameObject winScreen; // The win screen to be displayed
    private bool success; // A simple class variable to be used to check if the player has succeeded
    void Update() // Displays the win screen if the player has succeeded
    {
        if(success)
        {
            DisplayWinScreen(winScreen);
        }
    }
    void OnTriggerStay(Collider other) // When the player reaches the goal, success is set to true
    {
        if (success)
            return;
        if(other.gameObject.CompareTag("Player"))
        {
            success = true;
        }
    }
}