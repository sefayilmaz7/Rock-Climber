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
    
    private void OnTriggerEnter(Collider other)
    {
        var ragdoll = other.GetComponentInParent<Ragdoll>();
        if (!ragdoll)
            return;

        ragdoll.ConnectRagdoll(GetComponent<Rigidbody>());
        ColorizeRock();
        DisableConnectable();
    }

    private void DisableConnectable()
    {
        Destroy(this);
    }
}
