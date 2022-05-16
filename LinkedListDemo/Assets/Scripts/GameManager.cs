using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject WaypointPrefab;
    public GameObject Player;

    private PlayerScript playerScript;
    private LinkedList<GameObject> linkedList = new LinkedList<GameObject>();
    public ListNode<GameObject> headWaypoint = null;

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject waypoint = (GameObject)Instantiate(WaypointPrefab, new Vector3(Random.Range(1, 30), Random.Range(1, 30)), Quaternion.identity);
            waypoint.name = "Waypoint" + (10 - i);
            linkedList.Add(waypoint);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        headWaypoint = linkedList.Head;
        playerScript = Player.GetComponent<PlayerScript>();
        playerScript.Target = headWaypoint.Value;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTarget();
    }

    public void StartToRun()
    {
        playerScript.Target = headWaypoint.Value;
    }

    void ChangeTarget()
    {
        if (Player.gameObject.transform.position
            .Equals(headWaypoint.Value.gameObject.transform.position))
        {
            while (headWaypoint != null)
            {
                if (headWaypoint.NextNode != null)
                {
                    headWaypoint = headWaypoint.NextNode;
                    playerScript.Target = headWaypoint.Value;
                }
                break;
            }
        }
    }
}
