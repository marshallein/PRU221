using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRobotConrete : IRobotBuilder
{

    private Robot _mainRobot = new Robot();


    void ResetRobot()
    {
        this._mainRobot = new Robot();
    }

    public void AddHead(Sprite part)
    {
        _mainRobot.Head = part;
    }

    public void AddLeftPart(Sprite part)
    {
        _mainRobot.LeftArm = part;
    }

    public void AddLower(Sprite part)
    {
        _mainRobot.LowerBody = part;
    }

    public void AddRightPart(Sprite part)
    {
        _mainRobot.RightArm = part;
    }

    public void AddUpper(Sprite part)
    {
        _mainRobot.UpperBody = part;
    }

    public Robot AssembleRobot()
    {
        Robot result = this._mainRobot;

        this.ResetRobot();

        return result;
    }
}
