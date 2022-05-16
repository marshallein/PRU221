using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public Vector2 Location { get; set; }

    public WaypointScript(Vector2 location)
    {
        Location = location;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        this.gameObject.SetActive(false);
    }
}
