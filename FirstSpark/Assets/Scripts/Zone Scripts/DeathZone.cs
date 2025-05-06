using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject player; // Drag your Player here in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            RespawnManager.Instance.RespawnPlayer(player);
        }
    }
}