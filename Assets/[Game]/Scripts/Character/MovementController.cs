using UnityEngine;

public class MovementController : MonoBehaviour , IInputListener
{
    [SerializeField] private Ragdoll Ragdoll;
    public void SendRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);
            }
        }
    }

    private void Update()
    {
        SendRaycast();
    }
}
