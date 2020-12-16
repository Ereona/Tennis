using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RacketMovingBase : MonoBehaviour
{
    protected Racket _racket;

    public void SetRacket(Racket r)
    {
        _racket = r;
    }
}
