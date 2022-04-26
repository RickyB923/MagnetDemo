using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // The main variables and components of the Magnet 
    private Utilities utilities = new Utilities();
    [SerializeField] PlayerController player;
    [Header("True = Positive, False = Negative")]
    [SerializeField] bool polarity;
    private Rigidbody rb;
    private SphereCollider field;
    public Vector3 lastPosition;
    private float distanceFromPlayer;
    public float maxVelocity;
    void Start() // Initializes components
    {
        rb = this.GetComponent<Rigidbody>();
        rb.mass = utilities.CalculateMass(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        field = this.GetComponent<SphereCollider>();
    }
    void Update() // Gets important variables every frame
    {
        var currentPosition = transform.position;
        distanceFromPlayer = Vector3.Distance(player.lastPosition, lastPosition);
        lastPosition = currentPosition;
    }
    void FixedUpdate() // Clamps Rigidbody velocity
    {
        utilities.ClampVelocity(rb, maxVelocity);
    }
    void OnTriggerStay(Collider other) // Determines if the player is within the magnetic field of this magnet
    {
        if(other == player.field)
        {
            // These check the polarity of the magnet and the player and call the appropriate method accordingly
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

    void Attract() // Attraction logic
    {
        
        if(player.rb.mass > rb.mass) // Moves smaller magnet towards player
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
            Vector3 vector = transform.position - player.transform.position;
            float distance = Mathf.Clamp(Vector3.Magnitude(vector), 5f, 10f);
            vector.Normalize();
            vector *= 1 / distance;
            transform.position -= vector;
        }
        else if(player.rb.mass <= rb.mass) // Moves player towards larger magnet
        {
            //player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, 0.1f);
            Vector3 vector = player.transform.position - transform.position;
            float distance = Mathf.Clamp(Vector3.Magnitude(vector), 5f, 10f);
            vector.Normalize();
            vector *= 1 / distance;
            player.transform.position -= vector;
        } 
    }
    void Repel() // Repulsion logic
    {
        if(player.transform.localScale.x > transform.localScale.x) // Moves smaller magnet away from player
        { 
            Vector3 vector = transform.position - player.transform.position;
            float distance = Mathf.Clamp(Vector3.Magnitude(vector), 5f, 10f);
            vector.Normalize();
            vector *= 1/distance;
            transform.position += vector;  
        }
        else if(player.transform.localScale.x <= transform.localScale.x) // Moves player away from larger magnet
        {
            Vector3 vector = player.transform.position - transform.position;
            float distance = Mathf.Clamp(Vector3.Magnitude(vector), 5f, 10f);
            vector.Normalize();
            vector *= 1/distance;
            player.transform.position += vector;   
        } 
    }

}
