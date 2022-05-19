using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int amountToSpawn = 100;

    public KMeanMain kMeanMain = new KMeanMain();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            Point point = new Point { X = Random.Range(-10f, 10f), Y = Random.Range(-10f, 10f) };
            kMeanMain.points.Add(point);
        }
    }

}
