using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RacketChangePositionHandler : MonoBehaviour
{
    private Racket _racket;

    public void SetRacket(Racket racket)
    {
        _racket = racket;
    }

    void Start()
    {
        GlobalEvents.onRacketPositionChanged += GlobalEvents_onRacketPositionChanged;
    }

    void OnDestroy()
    {
        GlobalEvents.onRacketPositionChanged -= GlobalEvents_onRacketPositionChanged;
    }

    private void GlobalEvents_onRacketPositionChanged(Racket racket)
    {
        OnPositionChanged(racket);
    }

    protected abstract void OnPositionChanged(Racket r);
}
