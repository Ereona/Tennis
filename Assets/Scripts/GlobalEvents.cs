using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEvents
{
    public delegate void OnGameStarted();
    public static event OnGameStarted onGameStarted;
    public static void RaiseOnGameStarted()
    {
        onGameStarted?.Invoke();
    }

    public delegate void OnGameOver();
    public static event OnGameOver onGameOver;
    public static void RaiseOnGameOver()
    {
        onGameOver?.Invoke();
    }

    public delegate void OnTouchDown(Vector3 position);
    public static event OnTouchDown onTouchDown;
    public static void RaiseOnTouchDown(Vector3 position)
    {
        onTouchDown?.Invoke(position);
    }

    public delegate void OnTouch(Vector3 position);
    public static event OnTouch onTouch;
    public static void RaiseOnTouch(Vector3 position)
    {
        onTouch?.Invoke(position);
    }

    public delegate void OnTouchUp(Vector3 position);
    public static event OnTouchUp onTouchUp;
    public static void RaiseOnTouchUp(Vector3 position)
    {
        onTouchUp?.Invoke(position);
    }

    public delegate void OnRacketPositionChanged(Racket racket);
    public static event OnRacketPositionChanged onRacketPositionChanged;
    public static void RaiseOnRacketPositionChanged(Racket racket)
    {
        onRacketPositionChanged?.Invoke(racket);
    }

    public delegate void OnScoreChanged(int value);
    public static event OnScoreChanged onScoreChanged;
    public static void RaiseOnScoreChanged(int value)
    {
        onScoreChanged?.Invoke(value);
    }

    public delegate void OnBestScoreChanged(int value);
    public static event OnBestScoreChanged onBestScoreChanged;
    public static void RaiseOnBestScoreChanged(int value)
    {
        onBestScoreChanged?.Invoke(value);
    }
}
