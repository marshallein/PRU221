using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDirectories
{
    private IRobotBuilder _robotBuilder;

    public IRobotBuilder RobotBuilder { set { _robotBuilder = value; } }

    #region use
    public void BuildHeadPart(Sprite part)
    {
        this._robotBuilder.AddHead(part);
    }

    public void BuildLeftPart(Sprite part)
    {
        this._robotBuilder.AddLeftPart(part);
    }

    public void BuildRightPart(Sprite part)
    {
        this._robotBuilder.AddRightPart(part);
    }

    public void BuildUpperPart(Sprite part)
    {
        this._robotBuilder.AddUpper(part);
    }

    public void BuildLowerPart(Sprite part)
    {
        this._robotBuilder.AddLower(part);
    }

    #endregion

    public void BuildBasicRobot(Sprite head, Sprite leftArm, Sprite rightArm,Sprite upper,Sprite lower)
    {
        this._robotBuilder.AddHead(head);
        this._robotBuilder.AddUpper(upper);
        this._robotBuilder.AddLower(lower);
        this._robotBuilder.AddLeftPart(leftArm);
        this._robotBuilder.AddRightPart(rightArm);
    }

}

