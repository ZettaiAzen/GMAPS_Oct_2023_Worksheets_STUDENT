using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        // returns the length of the distance between the two position vectors
        return (p1-p2).Magnitude();
    }
}

