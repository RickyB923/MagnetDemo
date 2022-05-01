using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // A short UI script for displaying the player's current inputs
    // Not currently being used

    [SerializeField] PlayerController player;
    [SerializeField] GameObject instructions;
    [SerializeField] public bool showInstructions;
    void Start()
    {
        if(showInstructions)
        {
            instructions.SetActive(true);
        }
        else
        {
            instructions.SetActive(false);
        }
    }
}
