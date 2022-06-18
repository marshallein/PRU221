using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Sprite> Head;
    public List<Sprite> Upper;
    public List<Sprite> Lower;
    public List<Sprite> RightArm;
    public List<Sprite> LeftArm;

    public RobotObject robotPrefab;
    public Transform spawnPoint;

    public Button leftButton;
    public Button rightButton;

    private RobotDirectories _robotDirectories = new RobotDirectories();
    private BasicRobotConrete _robotBuilder = new BasicRobotConrete();
    private RobotObject robotObject;
    private Robot _robot;

    private void Start()
    {
        this._robotDirectories.RobotBuilder = _robotBuilder;

        robotObject = Instantiate<RobotObject>(robotPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void SetRobotPart()
    {
        robotObject.transform.Find("Head").GetComponent<SpriteRenderer>().sprite = _robot.Head;
        robotObject.transform.Find("LeftArm").GetComponent<SpriteRenderer>().sprite = _robot.LeftArm;
        robotObject.transform.Find("RightArm").GetComponent<SpriteRenderer>().sprite = _robot.RightArm;
        robotObject.transform.Find("Upper").GetComponent<SpriteRenderer>().sprite = _robot.UpperBody;
        robotObject.transform.Find("Lower").GetComponent<SpriteRenderer>().sprite = _robot.LowerBody;
    }

    public void OnClickStartBuildARandomRobot()
    {
        _robotDirectories.BuildBasicRobot(
            Head[Random.Range(0, Head.Count)],
            LeftArm[Random.Range(0, LeftArm.Count)],
            RightArm[Random.Range(0, RightArm.Count)],
            Upper[Random.Range(0, Upper.Count)],
            Lower[Random.Range(0, Lower.Count)]
            );

        _robot = _robotBuilder.AssembleRobot();
        robotObject.SetRobot(_robot);

        SetRobotPart();

        rightButton.gameObject.SetActive(true);
        leftButton.gameObject.SetActive(true);
    }

    public void OnClickChangeLeftArm()
    {
        _robot.LeftArm = LeftArm[Random.Range(0, LeftArm.Count)];
        SetRobotPart();
    }

    public void OnClickChangeRightArm()
    {
        _robot.RightArm = RightArm[Random.Range(0, RightArm.Count)];
        SetRobotPart();
    }



}
