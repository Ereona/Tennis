using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketInitializer : MonoBehaviour
{
    public RacketMovingBase RacketMoving;
    public List<RacketChangePositionHandler> PositionHandlers = new List<RacketChangePositionHandler>();
    public RacketInitialPositionProvider InitialPosProvider;
    public Racket RacketPrefab;

    private void Start()
    {
        Racket racket = Instantiate(RacketPrefab.gameObject).GetComponent<Racket>();
        RacketMoving.SetRacket(racket);
        foreach (RacketChangePositionHandler handler in PositionHandlers)
        {
            handler.SetRacket(racket);
        }
        racket.transform.position = InitialPosProvider.GetInitialPosition();
    }
}
