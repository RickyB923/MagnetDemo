using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utilities;

public class PuzzleManager : MonoBehaviour
{
    // This script is for managing the win condition of the Puzzle scene
    [SerializeField] Button[] buttons; // The array of buttons that need to be activated to win
    [SerializeField] GameObject winScreen; // The win screen to be displayed
    private bool success; // A simple class variable to be used to check if the player has succeeded
    void Update() // Checks for success and displays win screen if true
    {
        success = CheckButtons();
        if (success)
        {
            DisplayWinScreen(winScreen);
        }
    }
    public bool CheckButtons() // Runs a check to see if all buttons are switched on
    {
        bool success = true;
        foreach (Button b in buttons)
        {
            if (!b.onOffState)
            {
                success = false;
            }
        }
        return success;
    }
}