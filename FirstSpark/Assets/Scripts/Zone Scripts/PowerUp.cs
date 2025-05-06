using UnityEngine;
using System.Collections;
using StarterAssets;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        ThirdPersonController controller = other.GetComponent<ThirdPersonController>();
        if (controller != null)
        {
            controller.ApplySpeedBoost(5.0f, 8f); // 2x zo snel voor 5 seconden
        }
    }

}