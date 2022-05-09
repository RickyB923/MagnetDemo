using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This script manages the interactive elements of the main menu
    [SerializeField] public string nextScene; // Name of the scene to transition to
    [SerializeField] private Dropdown dropdown; // The dropdown element
    public void Transition() // Loads a scene based on a name
    {
        SceneManager.LoadScene(nextScene);
    }
    public void SetScene() // Sets the name of the scene from the dropdown's input
    {
        nextScene = dropdown.options[dropdown.value].text;
    }
}