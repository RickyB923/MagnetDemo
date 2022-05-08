using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] PlayerController player; // The current instance of the player
    [SerializeField] GameObject pauseScreen; // The pause screen to be shown
    void Update() // Checks if the player has paused the game
    {
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
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
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
