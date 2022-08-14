using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private Color ConnectedRockColor;

    public void ColorizeRock()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        if(!meshRenderer)
            return;
        meshRenderer.material.color = ConnectedRockColor;
    }
}
