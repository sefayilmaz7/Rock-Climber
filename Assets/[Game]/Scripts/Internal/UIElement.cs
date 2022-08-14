using DG.Tweening;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    [SerializeField] private float ExecuteTime;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        if(!canvasGroup)
            return;

        _canvasGroup = canvasGroup;
    }

    public void Execute()
    {
        Activate();
    }

    private void Activate()
    {
        gameObject.SetActive(true);
        _canvasGroup.DOFade(1, ExecuteTime);
    }
}
