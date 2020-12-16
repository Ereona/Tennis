using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallInitializerBase : MonoBehaviour
{
    public GameObject BallPrefab;
    protected GameObject BallInstance;

    void Start()
    {
        GlobalEvents.onGameStarted += GlobalEvents_onGameStarted;
    }

    private void OnDestroy()
    {
        GlobalEvents.onGameStarted -= GlobalEvents_onGameStarted;
    }

    private void GlobalEvents_onGameStarted()
    {
        DestroyBall();
        CreateBall();
    }

    private void DestroyBall()
    {
        if (BallInstance != null)
        {
            Destroy(BallInstance);
        }
    }

    protected abstract void CreateBall();
}
