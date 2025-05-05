using UnityEngine;

public class SimpleDialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueTextObject;
    [SerializeField] private bool oneTimeOnly = true;
    
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered && oneTimeOnly) return;

        if (other.CompareTag("Player"))
        {
            dialogueTextObject.SetActive(true);
            hasTriggered = true;
        }
    }
}