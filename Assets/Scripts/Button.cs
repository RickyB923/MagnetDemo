using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("True = On, False = Off")]
    [SerializeField] public bool onOffState;
    [Header("True = Needs Positive, False = Needs Negative")]
    [SerializeField] private bool neededPolarity;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Magnet"))
        {
            var magnet = other.gameObject.GetComponent<Magnet>();
            if(neededPolarity == magnet.polarity)
            {
                onOffState = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Magnet"))
        {
            var magnet = other.gameObject.GetComponent<Magnet>();
            if (neededPolarity == magnet.polarity)
            {
                onOffState = false;
            }
        }
    }
}
