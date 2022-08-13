using System;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-10)]
public class GameManager : SingletonBehaviour<GameManager>
{
    public event UnityAction GameStartedEvent;
    public event UnityAction LevelCompletedEvent;
    public event UnityAction LevelFailedEvent;

    private void Start()
    {
        LockFrameRate();
        GameStartedEvent.Invoke();
    }

    private void LockFrameRate()
    {
        Application.targetFrameRate = 60;
    }
}