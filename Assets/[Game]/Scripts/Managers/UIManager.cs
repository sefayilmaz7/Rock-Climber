using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIElement FailedGroup;
    [SerializeField] private UIElement CompletedGroup;

    private void ShowFailScreen()
    {
        FailedGroup.Execute();
    }

    private void ShowCompletedScreen()
    {
        CompletedGroup.Execute();
    }

    private void OnEnable()
    {
        GameManager.Instance.LevelCompletedEvent += ShowCompletedScreen;
        GameManager.Instance.LevelFailedEvent += ShowFailScreen;
    }

    private void OnDisable()
    {
        GameManager.Instance.LevelCompletedEvent -= ShowCompletedScreen;
        GameManager.Instance.LevelFailedEvent -= ShowFailScreen;
    }
}
