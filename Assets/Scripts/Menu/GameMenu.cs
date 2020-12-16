using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject ScoreObject;
    public Text ScoreText;

    void Start()
    {
        ScoreObject.SetActive(false);
        GlobalEvents.onGameStarted += GlobalEvents_onGameStarted;
        GlobalEvents.onGameOver += GlobalEvents_onGameOver;
        GlobalEvents.onScoreChanged += GlobalEvents_onScoreChanged;
    }

    void OnDestroy()
    {
        GlobalEvents.onGameStarted -= GlobalEvents_onGameStarted;
        GlobalEvents.onGameOver -= GlobalEvents_onGameOver;
        GlobalEvents.onScoreChanged -= GlobalEvents_onScoreChanged;
    }

    private void GlobalEvents_onGameStarted()
    {
        ScoreObject.SetActive(true);
        ScoreText.text = ScoresCounter.Score.ToString();
    }

    private void GlobalEvents_onGameOver()
    {
        ScoreObject.SetActive(false);
    }

    private void GlobalEvents_onScoreChanged(int value)
    {
        ScoreText.text = ScoresCounter.Score.ToString();
    }
}
