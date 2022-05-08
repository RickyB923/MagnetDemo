using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // This script is for the button GameObject, used for solving puzzles
    [Header("True = On, False = Off")]
    [SerializeField] public bool onOffState;
    [Header("True = Needs Positive, False = Needs Negative")]
    [SerializeField] private bool neededPolarity;
    [SerializeField] private PhysicMaterial referenceMaterial; // A material used to check if a magnet has collided with the button
    void OnTriggerEnter(Collider other) // Turns button on if the proper magnet enters the trigger
    {
        if (other.sharedMaterial != null)
        {
            if (other.sharedMaterial == referenceMaterial)
            {
                var magnet = other.gameObject.GetComponent<Magnet>();
                if (neededPolarity == magnet.polarity)
                {
                    onOffState = true;
                }
            }
        }
    }
    void OnTriggerExit(Collider other) // Turns the button off if the proper magnet leaves the trigger
    {
        if (other.sharedMaterial != null)
        {
            if (other.sharedMaterial == referenceMaterial)
            {
                var magnet = other.gameObject.GetComponent<Magnet>();
                if (neededPolarity == magnet.polarity)
                {
                    onOffState = false;
                }
            }
        }
    }
}
