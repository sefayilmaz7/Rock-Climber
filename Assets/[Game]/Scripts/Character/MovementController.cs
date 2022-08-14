using System;
using DG.Tweening;
using UnityEngine;

public class MovementController : MonoBehaviour , IInputListener
{
    [SerializeField] private Ragdoll ragdoll;
    [SerializeField] private MovementData MoveData;
    public void SendRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Climb(hit);
            }
        }
    }

    private void Climb(RaycastHit hit)
    {
        var rock = hit.collider.GetComponent<Rock>();
        if (!rock)
            return;
        ragdoll.Open();
        ragdoll.BreakRagdoll();
        var normalizedForce = ((rock.transform.position + Vector3.up) - ragdoll.GetForcePart().transform.position).normalized * (MoveData.moveSpeed * 100);
        ragdoll.ApplyForceAllParts(normalizedForce);
    }

    private void Update()
    {
        SendRaycast();
    }
    
}
