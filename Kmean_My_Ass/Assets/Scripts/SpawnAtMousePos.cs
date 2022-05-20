using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtMousePos : MonoBehaviour
{
    public Camera mainCamera;
    public PointObject pointObjectPrefab;
    public CentroidObject centroidObjectPrefab;
    public GameManager gameManager;

    private void Start()
    {
        mainCamera = Camera.main;
        gameManager = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

            mousePos.z = pointObjectPrefab.transform.position.z;

            SpawnPoint(mousePos);

        }
    }


    void SpawnPoint(Vector3 location)
    {
        var pointObject = Instantiate<PointObject>(pointObjectPrefab, location, Quaternion.identity);
        Point point = new Point();
        pointObject.SetPoint(point);
        gameManager.kMeanMain.points.Add(point);
    }
}
