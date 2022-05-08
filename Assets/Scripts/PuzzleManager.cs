using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] Button[] buttons; // The array of buttons that need to be activated to win
    [SerializeField] GameObject winScreen; // The win screen to be displayed
    private bool success; // A simple class variable to be used to check if the player has succeeded
    private bool gameOver;
    void Update()
    {
        if(!gameOver)
        {
            success = CheckButtons();
            if (success)
            {
                DisplayWinScreen();
                gameOver = true;
            }
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
    public void DisplayWinScreen() // Displays win screen
    {
        Cursor.lockState = CursorLockMode.None;
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
