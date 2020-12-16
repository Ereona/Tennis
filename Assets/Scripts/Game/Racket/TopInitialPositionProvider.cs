using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopInitialPositionProvider : RacketInitialPositionProvider
{
    public override Vector3 GetInitialPosition()
    {
        Vector3 maxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        return new Vector3(0, maxPoint.y, 0);
    }
}
