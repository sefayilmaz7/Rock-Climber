using System;
using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacle
{
    public void React(Collider other)
    {
        var ragdoll = other.GetComponentInParent<Ragdoll>();
        if (!ragdoll)
            return;
        GetComponent<Collider>().enabled = false;
        ragdoll.FallDown();
        GameManager.Instance.FailLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        React(other);
    }
    
}

public interface IObstacle
{
    void React(Collider other);
}