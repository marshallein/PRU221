using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Centroid : Point
{

    public List<Point> points = new List<Point>();

    public void UpdateLocation()
    {
        X = points.Sum(p => p.X) / points.Count;
        Y = points.Sum(p => p.Y) / points.Count;
    }

}

