using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string nextScene; // Name of the scene to transition to
    public void Transition()
    {
        SceneManager.LoadScene(nextScene);
    }
}
