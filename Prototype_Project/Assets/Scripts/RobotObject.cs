using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotObject : MonoBehaviour
{
    public Robot robot;


    private Rigidbody2D _rigidbody2D;
    private float _horizontal;

    public void SetRobot(Robot robot)
    {
        this.robot = robot;
        Debug.Log(this.robot.ToString());
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * 10, _rigidbody2D.velocity.y);
    }

}
