using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRacketMoving : RacketMovingBase
{
    private bool _movingInProgress = false;
    private Vector2 _movingLastPoint;
    private Camera mainCamera;

    private void Start()
    {
        GlobalEvents.onTouchDown += GlobalEvents_onTouchDown;
        GlobalEvents.onTouch += GlobalEvents_onTouch;
        GlobalEvents.onTouchUp += GlobalEvents_onTouchUp;
        mainCamera = Camera.main;
    }

    private void OnDestroy()
    {
        GlobalEvents.onTouchDown -= GlobalEvents_onTouchDown;
        GlobalEvents.onTouch -= GlobalEvents_onTouch;
        GlobalEvents.onTouchUp -= GlobalEvents_onTouchUp;
    }

    private void GlobalEvents_onTouchDown(Vector3 pos)
    {
        _movingInProgress = true;
        _movingLastPoint = pos;
    }

    private void GlobalEvents_onTouch(Vector3 pos)
    {
        if (_movingInProgress)
        {
            _racket.MoveRacket(CalcTranslation(pos));
            _movingLastPoint = pos;
        }
    }

    private void GlobalEvents_onTouchUp(Vector3 pos)
    {
        if (_movingInProgress)
        {
            _movingInProgress = false;
            _racket.MoveRacket(CalcTranslation(pos));
        }
    }

    private float CalcTranslation(Vector3 pos)
    {
        Vector3 worldPrev = mainCamera.ScreenToWorldPoint(_movingLastPoint);
        Vector3 worldCur = mainCamera.ScreenToWorldPoint(pos);
        return worldCur.x - worldPrev.x;
    }
}
