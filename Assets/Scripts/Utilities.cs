using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public float CalculateMass(float x, float y, float z)
    {
        float temp = new float();
        temp = x + y + z;
        return temp/3;
    }
    public void ClampVelocity(Rigidbody rb, float maxVelocity)
    {
        var clampedVelocityX = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        var clampedVelocityY = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);
        var clampedVelocityZ = Mathf.Clamp(rb.velocity.z, -maxVelocity, maxVelocity);
        rb.velocity = new Vector3(clampedVelocityX,clampedVelocityY,clampedVelocityZ);
    }
}
