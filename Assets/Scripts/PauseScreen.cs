using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    // This script manages the pause screen and its interactive elements
    [SerializeField] PlayerController player; // The current instance of the player
    [SerializeField] GameObject pauseScreen; // The pause screen to be shown
    [SerializeField] GameObject winScreen; // Needed to check if it's already on
    void Update() // Checks if the player has paused the game
    {
        if(winScreen.activeSelf)
            return;
        if(player.pauseInput)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }
    void Pause() // Pauses the game
    {
        Cursor.lockState = CursorLockMode.None;
        pauseScreen.SetActive(true);  
        Time.timeScale = 0;
    }
    void Unpause() // Unpauses the game
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void Reset() // Resets the current scene
    {
        var scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }
    public void MainMenu() // Loads the main menu
    {
        SceneManager.LoadScene("Main Menu");
    }
}