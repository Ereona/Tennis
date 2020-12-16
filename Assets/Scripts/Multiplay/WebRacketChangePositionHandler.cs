using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebRacketChangePositionHandler : RacketChangePositionHandler
{
    protected override void OnPositionChanged(Racket r)
    {
        // отправить информацию о новом положении на сервер
    }
}
