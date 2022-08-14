using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-10)]
public class GameManager : SingletonBehaviour<GameManager>
{
    public event UnityAction GameStartedEvent;
    public event UnityAction LevelCompletedEvent;
    public event UnityAction LevelFailedEvent;

    private void Start()
    {
        StartLevel();
    }

    private void LockFrameRate()
    {
        Application.targetFrameRate = 60;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CompleteLevel()
    {
        LevelCompletedEvent?.Invoke();
    }

    public void FailLevel()
    {
        LevelFailedEvent?.Invoke();
    }

    private void StartLevel()
    {
        GameStartedEvent?.Invoke();
    }
    
    private void OnEnable()
    {
        GameStartedEvent += LockFrameRate;
        LevelCompletedEvent += KillTweens;
        LevelFailedEvent += KillTweens;
    }

    private void OnDisable()
    {
        GameStartedEvent -= LockFrameRate;
        LevelCompletedEvent -= KillTweens;
        LevelFailedEvent -= KillTweens;
    }

    private void KillTweens()
    {
        DOTween.KillAll();
    }
}
