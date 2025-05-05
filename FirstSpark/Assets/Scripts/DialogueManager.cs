using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;
    public Text dialogueText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialogue(string message, float duration = 10f)
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = message;

        StopAllCoroutines(); // voorkom dat eerdere coroutines doorlopen
        StartCoroutine(HideDialogueAfterSeconds(duration));
    }

    private IEnumerator HideDialogueAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dialoguePanel.SetActive(false);
    }
}