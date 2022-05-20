using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMeanMain
{
    public List<Point> points = new List<Point>();
    public List<Centroid> centroids = new List<Centroid>();

    public Dictionary<Centroid, List<Point>> recordLocation = new Dictionary<Centroid, List<Point>>();

    /// <summary>
    /// start to train centroid
    /// </summary>
    /// <param name="k"></param>
    public void Train(int k)
    {
        // add centroid equal to k
        for (int i = 0; i < k; i++)
        {
            Centroid centroid = new Centroid { X = Random.Range(-5, 5f), Y = Random.Range(-5f, 5f) };
            centroids.Add(centroid);
        }

        foreach (var centroid in centroids)
        {
            recordLocation[centroid] = new List<Point>();
            recordLocation[centroid].Add(new Point { X = centroid.X, Y = centroid.Y });
        }

        bool anyPointGroupChanged = false;
        int count = 0;
        do
        {

            Debug.Log("interation " + count++);
            anyPointGroupChanged = false;
            // loop through points List.
            // find nearest centroid from every point.
            foreach (var point in points)
            {
                float minDistance = float.MaxValue;
                Centroid nearestCentroid = null;

                // for loop to find nearest centroid
                foreach (var centroid in centroids)
                {
                    float distance = point.Distance(centroid);
                    if (distance < minDistance)
                    {
                        nearestCentroid = centroid;
                        minDistance = distance;
                    }
                }

                // if the nearest centroid is not the same centroid store in point
                if (nearestCentroid != point.Centroid)
                {
                    if (point.Centroid != null)
                    {
                        // remove the point on that point's centroid
                        point.Centroid.points.Remove(point);

                    }
                    nearestCentroid.points.Add(point);
                    point.Centroid = nearestCentroid;
                    anyPointGroupChanged = true;
                }
            }

            //if any point has changed the centroid, center the centroid again
            if (anyPointGroupChanged)
            {
                // loop for update location X Y of all centroid
                foreach (var centroid in centroids)
                {
                    centroid.UpdateLocation();
                    recordLocation[centroid].Add(new Point { X = centroid.X, Y = centroid.Y });
                }
            }


        } while (anyPointGroupChanged);

    }


}
