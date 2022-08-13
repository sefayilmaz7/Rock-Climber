using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIElement failedGroup;
    [SerializeField] private UIElement completedGroup;

    private void ShowFailScreen()
    {
        failedGroup.Execute();
    }

    private void ShowCompletedScreen()
    {
        completedGroup.Execute();
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
