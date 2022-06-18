using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : ICloneable
{
    public Sprite LeftArm { get; set; }
    public Sprite RightArm { get; set; }
    public Sprite UpperBody { get; set; }
    public Sprite LowerBody { get; set; }
    public Sprite Head { get; set; }

    public Robot()
    {
    }

    public Robot(Sprite leftArm, Sprite rightArm, Sprite upperBody, Sprite downperBody, Sprite head)
    {
        LeftArm = leftArm;
        RightArm = rightArm;
        UpperBody = upperBody;
        LowerBody = downperBody;
        Head = head;
    }

    public override string ToString()
    {
        return $"Left Arm : {LeftArm.name}, Right Arm : {RightArm.name}, Upper : {UpperBody.name}, Lower : {LowerBody.name}, Head : {Head.name}";
    }

    public object Clone()
    {
        return this.MemberwiseClone() as Robot;
    }
}
