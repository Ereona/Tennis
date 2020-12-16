using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RacketInitialPositionProvider : MonoBehaviour
{
    public abstract Vector3 GetInitialPosition();
}
