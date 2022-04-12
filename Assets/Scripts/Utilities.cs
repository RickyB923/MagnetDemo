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
}
