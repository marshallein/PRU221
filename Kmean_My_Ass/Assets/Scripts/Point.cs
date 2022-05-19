using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public float X { get; set; }
    public float Y { get; set; }


    public Centroid Centroid { get; set; }

    public float Distance(Point point)
    {
        return Mathf.Sqrt(Mathf.Pow(point.X - X, 2) + Mathf.Pow(point.Y - Y, 2));
    }


}
