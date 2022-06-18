using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRobotBuilder
{

    void AddLeftPart(Sprite part);
    void AddRightPart(Sprite part);
    void AddUpper(Sprite part);
    void AddLower(Sprite part);
    void AddHead(Sprite part);

}
