using UnityEngine;
using System.Collections;

public class SpiritNPC : MonoBehaviour
{
    public GameObject fadeOutEffect;
    private bool isActivated = false;

    private void OnTriggerStay(Collider other)
    {
        if (!isActivated && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            isActivated = true;
            SpiritManager.Instance.SpiritFound();
            StartCoroutine(FadeAndDestroy());
        }
    }

    private IEnumerator FadeAndDestroy()
    {
        if (fadeOutEffect) fadeOutEffect.SetActive(true);
        yield return new WaitForSeconds(2f); // of afhankelijk van je effect
        Destroy(gameObject);
    }
}