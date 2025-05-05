using UnityEngine;
using UnityEngine.UI;

public class SpiritInteraction : MonoBehaviour
{
    public GameObject interactionUI; // UI Text "E to talk"
    private bool isPlayerInRange = false;

    void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithSpirit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }

    void InteractWithSpirit()
    {
        Debug.Log("Interacted with Spirit.");
        // Voeg hier fade out, VFX, of vervolglogica toe
    }
}