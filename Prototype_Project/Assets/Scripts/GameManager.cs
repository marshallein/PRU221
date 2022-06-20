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
    public Button cloneButton;

    private RobotDirectories _robotDirectories = new RobotDirectories();
    private BasicRobotConrete _robotBuilder = new BasicRobotConrete();
    private Robot _robot;
    private RobotObject robotObject;

    private RobotObject robotClone;

    private void Start()
    {
        this._robotDirectories.RobotBuilder = _robotBuilder;

        robotObject = Instantiate<RobotObject>(robotPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void SetRobotPart(RobotObject robotObject)
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

        robotObject.tagname.SetText("Main Robot");

        SetRobotPart(robotObject);

        rightButton.gameObject.SetActive(true);
        leftButton.gameObject.SetActive(true);
        cloneButton.gameObject.SetActive(true);
    }

    public void OnClickChangeLeftArm()
    {
        _robot.LeftArm = LeftArm[Random.Range(0, LeftArm.Count)];
        SetRobotPart(robotObject);
    }

    public void OnClickChangeRightArm()
    {
        _robot.RightArm = RightArm[Random.Range(0, RightArm.Count)];
        SetRobotPart(robotObject);
    }


    public void OnClickCloneRobot()
    {
        robotClone = Instantiate<RobotObject>(robotPrefab, spawnPoint.position, Quaternion.identity);
        robotClone.SetRobot(_robot.Clone() as Robot);

        robotClone.tagname.SetText("Clone Robot");

        SetRobotPart(robotClone);
    }


}
