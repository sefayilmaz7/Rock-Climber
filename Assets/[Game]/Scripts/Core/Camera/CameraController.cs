using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float CameraOffsetY = 2;

    private void LateUpdate()
    {
        transform.DOMoveY(Target.position.y + CameraOffsetY, 1);
    }
}
