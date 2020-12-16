using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresCounter : MonoBehaviour
{
    private void Start()
    {
        GlobalEvents.onGameStarted += GlobalEvents_onGameStarted;
        GlobalEvents.onGameOver += GlobalEvents_onGameOver;
    }

    private void OnDestroy()
    {
        GlobalEvents.onGameStarted -= GlobalEvents_onGameStarted;
        GlobalEvents.onGameOver -= GlobalEvents_onGameOver;
    }

    private void GlobalEvents_onGameStarted()
    {
        Score = 0;
    }

    private void GlobalEvents_onGameOver()
    {
        if (Score > BestScore)
        {
            BestScore = Score;
            GlobalEvents.RaiseOnBestScoreChanged(Score);
        }
    }

    public static int BestScore
    {
        get
        {
            return PlayerPrefs.GetInt("BestScore", 0);
        }
        set
        {
            PlayerPrefs.SetInt("BestScore", value);
        }
    }

    private static int _score;
    public static int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            GlobalEvents.RaiseOnScoreChanged(value);
        }
    }
}
