using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int amountToSpawn = 100;
    [Range(2, 4)]
    public int amountCentroidToSpawn = 3;

    public PointObject Point;
    public CentroidObject Centroid;
    public bool randomVer = true;
    public KMeanMain kMeanMain = new KMeanMain();

    Dictionary<Centroid, CentroidObject> cenrtroidMap = new Dictionary<Centroid, CentroidObject>();
    Dictionary<Point, PointObject> pointMap = new Dictionary<Point, PointObject>();

    private int _interation = 0;
    private bool inProgress = false;


    // Start is called before the first frame update
    void Start()
    {
        if (randomVer)
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                Point point = new Point { X = Random.Range(-5f, 5f), Y = Random.Range(-5f, 5f) };
                kMeanMain.points.Add(point);
            }
        }

        kMeanMain.Train(amountCentroidToSpawn);

        Visualize();
    }


    public void Visualize()
    {


        foreach (Point point in kMeanMain.points)
        {
            var pointObject = Instantiate<PointObject>(Point, new Vector2(point.X, point.Y), Quaternion.identity);
            pointObject.SetPoint(point);

            pointMap.Add(point, pointObject);
        }

        int count = 0;
        foreach (var centroid in kMeanMain.centroids)
        {
            var startPosition = kMeanMain.recordLocation[centroid][0];

            var centroidObject = Instantiate<CentroidObject>(Centroid, new Vector2(startPosition.X, startPosition.Y), Quaternion.identity);
            centroidObject.name = "Centroid " + count++;
            centroidObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

            centroidObject.SetCentroid(centroid);

            cenrtroidMap.Add(centroid, centroidObject);
        }


        _interation = 1;
        inProgress = true;
    }


    private void Update()
    {

        if (!inProgress) return;

        Debug.Log(_interation);

        bool centroidsToCorrectposition = true;
        foreach (CentroidObject centroid in cenrtroidMap.Values)
        {
            var positonToMove = kMeanMain.recordLocation[centroid.Centroid][_interation];
            var position = new Vector2(positonToMove.X, positonToMove.Y);

            centroid.transform.position = Vector3.MoveTowards(centroid.transform.position, position, 3f * Time.deltaTime);

            if (centroidsToCorrectposition && Vector3.Distance(centroid.transform.position, position) > 0.0001f)
            {
                {
                    centroidsToCorrectposition = false;
                }
            }
        }

        if (centroidsToCorrectposition)
        {
            _interation++;

            if (_interation >= kMeanMain.recordLocation.Values.FirstOrDefault().Count)
            {
                inProgress = false;
            }
        }
        else
        {
            ColorThePoint();
        }
    }

    private void ColorThePoint()
    {
        foreach (CentroidObject centroid in cenrtroidMap.Values)
        {
            foreach (var point in centroid.Centroid.points)
            {
                pointMap.Values.First(x => x.Point == point).GetComponent<SpriteRenderer>().color
                    = centroid.GetComponent<SpriteRenderer>().color;

            }
        }
    }
}
