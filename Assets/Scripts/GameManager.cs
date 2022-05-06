using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("True = Puzzle, False = Other")]
    [SerializeField] bool gameType;
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject winScreen;
    private bool success;
    void Update() // Displays win screen if check is successful
    {
        if(gameType)
        {
            success = CheckButtons();
        }
        if (success)
        {
            Cursor.lockState = CursorLockMode.None;
            winScreen.SetActive(true);
            Time.timeScale = 0;
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


//trying to figure out why ui buttons won't work in puzzle scene
// strange index null error also
