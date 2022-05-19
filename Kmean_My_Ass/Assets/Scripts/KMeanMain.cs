using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMeanMain
{
    public List<Point> points = new List<Point>();
    public List<Centroid> centroids = new List<Centroid>();

    /// <summary>
    /// start to train centroid
    /// </summary>
    /// <param name="k"></param>
    public void Train(int k)
    {
        for (int i = 0; i < k; i++)
        {
            Centroid centroid = new Centroid { X = Random.Range(-10f, 10f), Y = Random.Range(-10f, 10f) };
            centroids.Add(centroid);
        }


        do
        {
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
                        minDistance = distance;
                        nearestCentroid = centroid;
                    }
                }

                point.Centroid = nearestCentroid;

            }

            
        } while (true);

    }


}
