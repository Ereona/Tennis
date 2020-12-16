using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomInitialPositionProvider : RacketInitialPositionProvider
{
    public override Vector3 GetInitialPosition()
    {
        Vector3 minPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        return new Vector3(0, minPoint.y, 0);
    }
}
