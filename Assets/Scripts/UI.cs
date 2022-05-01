using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject pauseScreen;
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
        pauseScreen.SetActive(true);  
        Time.timeScale = 0;
    }
    void Unpause() // Unpauses the game
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
