using EasyButtons;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private AwakeStatus awakeStatus; private enum AwakeStatus { OpenOnAwake, CloseOnAwake }
    [SerializeField] private Rigidbody ForcePart;
    [SerializeField] private List<Rigidbody> Rigidbodies;
    [SerializeField] private List<Collider> Colliders;

    public System.Action<bool> StatusChangedEvent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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

    public void Open()
    {
        if (_animator) _animator.enabled = false;
        if (Rigidbodies.Count == 0) return;
        Rigidbodies.ForEach(obj => obj.isKinematic = false);
        Colliders.ForEach(obj => obj.isTrigger = false);

        StatusChangedEvent?.Invoke(true);
    }

    public void Close()
    {
        if (_animator) _animator.enabled = true;
        if (Rigidbodies.Count == 0) return;
        Rigidbodies.ForEach(obj => obj.isKinematic = true);
        Colliders.ForEach(obj => obj.isTrigger = true);

        StatusChangedEvent?.Invoke(false);
    }

    public void ApplyForceTargetPart(Vector3 force)
    {
        if (!ForcePart) return;
        ForcePart.AddForce(force, ForceMode.Force);
    }

    public void ApplyForceAllParts(Vector3 force)
    {
        if (Rigidbodies.Count == 0) return;
        Rigidbodies.ForEach(x => x.AddForce(force, ForceMode.Force));
    }
}