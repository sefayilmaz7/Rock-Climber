using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraData", menuName = "Data/CameraData", order = 2)]
public class CameraData : ScriptableObject
{
    public float cameraOffsetY = 2;
    public Ease cameraMoveEase;
    public Material skyboxMaterial;
}
