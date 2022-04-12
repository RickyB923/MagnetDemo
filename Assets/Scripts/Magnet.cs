using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [Header("True = Positive, False = Negative")]
    [SerializeField] bool polarity;
    [SerializeField] float weight;
    private Rigidbody rb;
    private SphereCollider field;
    public Vector3 lastPosition;
    private float distanceFromPlayer;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        field = this.GetComponent<SphereCollider>();
    }
    void Update()
    {
        var currentPosition = transform.position;
        distanceFromPlayer = Vector3.Distance(player.lastPosition, lastPosition);
        //Debug.Log($"{distanceFromPlayer}");
        lastPosition = currentPosition;
    }
    void FixedUpdate()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other == player.field)
        {
            if(player.polarity == 1)
            {
                if(polarity == true)
                {
                    Attract();
                }
                else
                {
                    Repel();
                }
            }
            else if(player.polarity == -1)
            {
                if(polarity == false)
                {
                    Attract();
                }
                else
                {
                    Repel();
                }
            }
        }
    }

    void Attract()
    {
        if(player.weight > weight)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.lastPosition + Vector3.forward, 0.1f);
        }
        else if(player.weight <= weight)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, lastPosition, 0.1f);
        }
    }
    void Repel()
    {
        if(player.weight > weight)
        {
            transform.position = Vector3.MoveTowards(transform.position, -player.lastPosition, 0.1f);
        }
        else if(player.weight <= weight)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, -lastPosition, 0.1f);
            //Not repelling away from magnet
        }
    }
}
