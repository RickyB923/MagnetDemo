using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject winScreen; // The win screen to be displayed
    private bool gameOver;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!gameOver)
            {
                gameManager.DisplayWinScreen();
                gameOver = true;
            }
        }
    }
}
