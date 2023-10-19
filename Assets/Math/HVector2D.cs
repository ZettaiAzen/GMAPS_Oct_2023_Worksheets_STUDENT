using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x + b.x, a.y + b.y);
    }

    public static HVector2D operator -(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x - b.x, a.y - b.y);
    }

    public static HVector2D operator *(HVector2D a, float scalar)
    {
        return new HVector2D(a.x * scalar, a.y * scalar);
    }

    public static HVector2D operator /(HVector2D a, float scalar)
    {
        return new HVector2D(a.x / scalar, a.y / scalar);
    }

    public float Magnitude()
    {
        double xSquared = Math.Pow(Convert.ToDouble(this.x), 2);
        double ySquared = Math.Pow(Convert.ToDouble(this.y), 2);
        double addedSquares = xSquared + ySquared;
        double mag = Math.Sqrt(addedSquares);
        return (float)mag;

    }

    public HVector2D Normalize()
    {
        float mag = Magnitude();
        x = this.x / mag;
        y = this.y / mag;
        return new HVector2D(x, y);
    }

    public float DotProduct(HVector2D v1, HVector2D v2)
    {
        x = v1.x * v2.x;
        y = v1.y * v2.y;
        return x + y;
    }

    public HVector2D Projection(HVector2D v1, HVector2D v2)
    {
        float dotPro = DotProduct(v1, v2);
        double magSquared = Math.Pow(v2.Magnitude(), 2);
        double leftSide = dotPro / magSquared;
        double x = leftSide * v2.x;
        double y = leftSide * v2.y;

        return new HVector2D((float)x, (float)y);
    }

    // public float FindAngle(/*???*/)
    // {

    // }

    public Vector2 ToUnityVector2()
    {
        return new Vector2(this.x, this.y);
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(this.x, this.y, 0);
    }

    // public void Print()
    // {

    // }
}
