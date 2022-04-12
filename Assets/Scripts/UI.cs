using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject rightText;
    [SerializeField] GameObject leftText;
    void Update()
    {
        if(player.polarity > 0)
        {
            rightText.SetActive(true);
        }
        else if(player.polarity < 0)
        {
            leftText.SetActive(true);
        }
        else
        {
            rightText.SetActive(false);
            leftText.SetActive(false);
        }
    }
}
