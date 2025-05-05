using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelTravelTrigger : MonoBehaviour
{
    public string targetSceneName = "OutsideLevel"; // Of CaveLevel afhankelijk van richting
    public GameObject promptUI; // "Press E to travel"
    public GameObject loadingScreen;
    public Image levelThumbnail; // Thumbnail Image component
    public Sprite thumbnailSprite; // Je plaatst hier de gewenste screenshot
    public float loadingDuration = 3f;

    private bool isPlayerInTrigger = false;

    private void Start()
    {
        promptUI?.SetActive(false);
        loadingScreen?.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(LoadSceneWithDelay());
        }
    }

    private IEnumerator LoadSceneWithDelay()
    {
        promptUI.SetActive(false);
        loadingScreen.SetActive(true);
        if (levelThumbnail != null && thumbnailSprite != null)
            levelThumbnail.sprite = thumbnailSprite;

        yield return new WaitForSeconds(loadingDuration);

        SceneManager.LoadScene(targetSceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            promptUI?.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            promptUI?.SetActive(false);
        }
    }
}