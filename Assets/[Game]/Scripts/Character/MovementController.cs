using System;
using DG.Tweening;
using UnityEngine;

public class MovementController : MonoBehaviour , IInputListener
{
    [SerializeField] private Ragdoll ragdoll;
    [SerializeField] private float Speed;
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
        ragdoll.ApplyForceAllParts((rock.transform.position - transform.position).normalized * (Speed * 100));
    }

    private void Update()
    {
        SendRaycast();
    }
    
}
