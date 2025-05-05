using TMPro;
using UnityEngine;
using System.Collections;

public class DialoguePopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Coroutine showCoroutine;

    public void ShowDialogue(string message, float duration = 8f)
    {
        if (showCoroutine != null)
            StopCoroutine(showCoroutine);

        showCoroutine = StartCoroutine(ShowCoroutine(message, duration));
    }

    private IEnumerator ShowCoroutine(string message, float duration)
    {
        dialogueText.text = message;
        dialogueText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        dialogueText.gameObject.SetActive(false);
    }
}