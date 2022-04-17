using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private Utilities utilities = new Utilities();
    [SerializeField] PlayerController player;
    [Header("True = Positive, False = Negative")]
    [SerializeField] bool polarity;
    private Rigidbody rb;
    private SphereCollider field;
    public Vector3 lastPosition;
    private float distanceFromPlayer;
    public float maxVelocity;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.mass = utilities.CalculateMass(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        field = this.GetComponent<SphereCollider>();
    }
    void Update()
    {
        var currentPosition = transform.position;
        distanceFromPlayer = Vector3.Distance(player.lastPosition, lastPosition);
        lastPosition = currentPosition;
    }
    void FixedUpdate()
    {
        utilities.ClampVelocity(rb, maxVelocity);
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
        
        if(player.rb.mass > rb.mass) //moving smaller magnet to player
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
            //rb.AddForce(player.lastPosition, ForceMode.Acceleration);
        }
        else if(player.rb.mass <= rb.mass) //moving player to larger magnet
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, 0.1f);
            //player.rb.AddForce(lastPosition, ForceMode.Acceleration);
        }
    }
    void Repel()
    {
        if(player.rb.mass > rb.mass) //moving small magnet away from player
        { 
            //var angle = Vector3.Angle(player.transform.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
            //rb.AddForce(-player.lastPosition, ForceMode.Acceleration);
        }
        else if(player.rb.mass <= rb.mass) //moving player away from larger magnet
        {
            //var angle = Vector3.Angle(transform.position, player.transform.position);
            player.transform.position = Vector3.MoveTowards(player.transform.position, -transform.position, 0.1f);
            //player.rb.AddForce(-lastPosition, ForceMode.Acceleration);
        } 
    }

}
