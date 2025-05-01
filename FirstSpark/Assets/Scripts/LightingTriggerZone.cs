using UnityEngine;

public class LightingTriggerZone : MonoBehaviour
{
    public LightingStateManager.LightingState targetState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var manager = FindObjectOfType<LightingStateManager>();
            if (manager != null)
            {
                manager.SetState(targetState);
            }
        }
    }
}