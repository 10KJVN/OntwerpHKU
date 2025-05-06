using UnityEngine;
using UnityEngine.UI;

public class WinZone : MonoBehaviour
{
    public GameObject titlePopup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            titlePopup.SetActive(true); // Toon de titel
            // Hier kan je ook een fade-to-black of restored profile aanroepen
        }
    }
}