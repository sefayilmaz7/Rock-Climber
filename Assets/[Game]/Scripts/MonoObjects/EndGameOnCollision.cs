using UnityEngine;

public class EndGameOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var ragdoll = other.GetComponentInParent<Ragdoll>();
        if(!ragdoll)
            return;
        GetComponent<Collider>().enabled = false;
        GameManager.Instance.CompleteLevel();
    }
}
