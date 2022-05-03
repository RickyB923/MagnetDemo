using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public string nextScene; // Name of the scene to transition to
    [SerializeField] private Dropdown dropdown;
    public void Transition()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void SetScene()
    {
        nextScene = dropdown.options[dropdown.value].text;
    }
}
