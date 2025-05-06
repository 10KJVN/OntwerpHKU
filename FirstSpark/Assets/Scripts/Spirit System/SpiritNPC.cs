using UnityEngine;
using System.Collections;

public class SpiritNPC : MonoBehaviour
{
    [SerializeField] private GameObject fadeOutEffect;
    [SerializeField] private GameObject interactText;

    private bool isPlayerInRange = false;
    private bool isActivated = false;

    private void Start()
    {
        if (interactText != null)
            interactText.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInRange && !isActivated && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithSpirit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;

            if (!isActivated && interactText != null)
                interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            if (interactText != null)
                interactText.SetActive(false);
        }
    }

    private void InteractWithSpirit()
    {
        isActivated = true;

        if (interactText != null)
            interactText.SetActive(false);

        // Trigger progress
        SpiritManager.Instance.SpiritFound();

        StartCoroutine(FadeAndDestroy());
    }

    private IEnumerator FadeAndDestroy()
    {
        if (fadeOutEffect != null)
            fadeOutEffect.SetActive(true);

        yield return new WaitForSeconds(2f); // duur fade effect

        Destroy(gameObject);
    }
}