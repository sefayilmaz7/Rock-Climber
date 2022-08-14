using System;
using EasyButtons;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private AwakeStatus awakeStatus; private enum AwakeStatus { OpenOnAwake, CloseOnAwake }
    [SerializeField] private Rigidbody ForcePart;
    [SerializeField] private List<Rigidbody> Rigidbodies;
    [SerializeField] private List<Collider> Colliders;
    [SerializeField] private List<GameObject> Arms;

    public System.Action<bool> StatusChangedEvent;

    private void Awake()
    {
        if (awakeStatus == AwakeStatus.OpenOnAwake) Open(); else Close();
    }

    [Button]
    [ContextMenu("Auto Find Rigidbodies and Colliders")]
    public void AutoFindReferences()
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        Rigidbodies = new List<Rigidbody>();
        Rigidbodies.AddRange(rigidbodies);

        Collider[] colliders = GetComponentsInChildren<Collider>();
        Colliders = new List<Collider>();
        Colliders.AddRange(colliders);
    }

    [Button("Test Ragdoll")]
    public void Open()
    {
        if (Rigidbodies.Count == 0) return;
        Rigidbodies.ForEach(obj => obj.isKinematic = false);
        Colliders.ForEach(obj => obj.isTrigger = false);

        StatusChangedEvent?.Invoke(true);
    }

    public void Close()
    {
        if (Rigidbodies.Count == 0) return;
        Rigidbodies.ForEach(obj => obj.isKinematic = true);
        Colliders.ForEach(obj => obj.isTrigger = true);

        StatusChangedEvent?.Invoke(false);
    }

    public void ApplyForceTargetPart(Vector3 force)
    {
        if (!ForcePart) return;
        ForcePart.AddForce(force , ForceMode.Impulse);
    }

    public void ApplyForceAllParts(Vector3 force)
    {
        if (Rigidbodies.Count == 0) return;
        Rigidbodies.ForEach(x => x.AddForce(force, ForceMode.Force));
    }

    public void ConnectRagdoll(Rigidbody connectedRigidbody)
    {
        foreach (var arm in Arms)
        {
            var joint = arm.AddComponent<HingeJoint>();
            joint.connectedBody = connectedRigidbody;
        }
    }

    public void BreakRagdoll()
    {
        var joints = GetComponentsInChildren<HingeJoint>();
        if(joints.Length == 0)
            return;
        foreach (var joint in joints)
        {
            Destroy(joint);
        }
    }
    
}