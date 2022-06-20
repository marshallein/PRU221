using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotObject : MonoBehaviour
{
    public Robot robot;
    public TMP_Text tagname;
    public Transform groundCheck;
    public LayerMask layerGround;

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

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 20f;
            _rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * 10, _rigidbody2D.velocity.y);

        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, layerGround);
        
    }


}
