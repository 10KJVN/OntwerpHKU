using UnityEngine;
using System.Collections;

public class FireflyManager : MonoBehaviour
{
    public GameObject[] fireflySequence; // Sleep 7 prefab instances in juiste volgorde in de Inspector
    public float gameTime = 50f;
    
    [SerializeField] private FireflyUIManager uiManager;

    private int currentIndex = 0;
    private float timer;
    private bool gameActive = false;
    private float logTimer = 0f;

    void Start()
    {
        DeactivateAll();
    }

    public void StartFireflyChallenge()
    {
        gameActive = true;
        timer = gameTime;
        ActivateNextFirefly();
    }

    void Update()
    {
        if (!gameActive) return;

        timer -= Time.deltaTime;

        // UI bijwerken elke frame
        if (uiManager != null)
            uiManager.UpdateTimer(timer);

        if (timer <= 0f)
        {
            gameActive = false;
            Debug.Log("Time's up! YOU LOSE!");
        }
    }


    public void FireflyCollected()
    {
        fireflySequence[currentIndex].SetActive(false);
        currentIndex++;

        if (uiManager != null)
            uiManager.UpdateFireflyCount(currentIndex, fireflySequence.Length);

        if (currentIndex < fireflySequence.Length)
        {
            ActivateNextFirefly();
        }
        else
        {
            gameActive = false;
            Debug.Log("All fireflies collected! YOU WIN!");
        }
    }


    void ActivateNextFirefly()
    {
        fireflySequence[currentIndex].SetActive(true);
    }

    void DeactivateAll()
    {
        foreach (GameObject f in fireflySequence)
        {
            f.SetActive(false);
        }
    }

    public float GetRemainingTime() => timer;
}