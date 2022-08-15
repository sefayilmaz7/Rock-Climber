using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraData CameraData;
    [SerializeField] private Transform Target;

    private void LateUpdate()
    {
        var ease = CameraData.cameraMoveEase;
        transform.DOMoveY(Target.position.y + CameraData.cameraOffsetY, 1).SetEase(ease);
    }

    private void SetSkyBox()
    {
        GetComponentInChildren<Skybox>().material = CameraData.skyboxMaterial;
    }
    
    private void Awake()
    {
        SetSkyBox();
    }
}
