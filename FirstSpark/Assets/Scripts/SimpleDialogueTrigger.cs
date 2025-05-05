using UnityEngine;
using System.Collections;

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
            StartCoroutine(ShowAndHide());

            hasTriggered = true;
        }
    }
    
    private IEnumerator ShowAndHide()
    {
        dialogueTextObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        dialogueTextObject.SetActive(false);
    }

}