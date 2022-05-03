using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    // A short utility script for methods that need to be called in multiple other scripts

    public float CalculateMass(float x, float y, float z) // Calculates the mass of a Rigidbody based on a GameObject's scale
    {
        float temp = x + y + z;
        return temp/3f;
    }
    public Vector3 ClampVelocity(Rigidbody rb, float maxVelocity) // Clamps a Rigidbody's velocity based on passed in parameters
    {
        var clampedVelocityX = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        var clampedVelocityY = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);
        var clampedVelocityZ = Mathf.Clamp(rb.velocity.z, -maxVelocity, maxVelocity);
        return new Vector3(clampedVelocityX,clampedVelocityY,clampedVelocityZ);
    }   
}
