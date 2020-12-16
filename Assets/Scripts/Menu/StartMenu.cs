using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button StartButton;
    public GameObject ScoreObject;
    public Text ScoreText;
    public Text BestScoreText;

    void Start()
    {
        ScoreObject.SetActive(false);
        StartButton.onClick.AddListener(StartGame);
        GlobalEvents.onGameOver += GlobalEvents_onGameOver;
        GlobalEvents.onBestScoreChanged += GlobalEvents_onBestScoreChanged;
        BestScoreText.text = ScoresCounter.BestScore.ToString();
    }

    private void OnDestroy()
    {
        GlobalEvents.onGameOver -= GlobalEvents_onGameOver;
        GlobalEvents.onBestScoreChanged -= GlobalEvents_onBestScoreChanged;
    }

    private void GlobalEvents_onGameOver()
    {
        this.gameObject.SetActive(true);
        ScoreObject.SetActive(true);
        ScoreText.text = ScoresCounter.Score.ToString();
        BestScoreText.text = ScoresCounter.BestScore.ToString();
    }

    private void GlobalEvents_onBestScoreChanged(int value)
    {
        BestScoreText.text = value.ToString();
    }


    private void StartGame()
    {
        GlobalEvents.RaiseOnGameStarted();
        this.gameObject.SetActive(false);
    }
}
