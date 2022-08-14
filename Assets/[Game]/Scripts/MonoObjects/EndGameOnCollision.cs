using UnityEngine;

public class EndGameOnCollision : MonoBehaviour, IFinish
{
    private void OnTriggerEnter(Collider other)
    {
        FinishGame(other);
    }
    
    public void FinishGame(Collider other)
    {
        var ragdoll = other.GetComponentInParent<Ragdoll>();
        if (!ragdoll)
            return;
        GetComponent<Collider>().enabled = false;
        GameManager.Instance.CompleteLevel();
    }
}

public interface IFinish
{
    void FinishGame(Collider other);
}
