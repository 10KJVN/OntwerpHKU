using UnityEngine;
using System.Collections;

public class FireflyManager : MonoBehaviour
{
    public GameObject[] fireflySequence; // Sleep 7 prefab instances in juiste volgorde in de Inspector
    public float gameTime = 50f;
    
    [SerializeField] private FireflyUIManager uiManager;
    //[SerializeField] private GameOverController gameOverController;
    //[SerializeField] private GameObject gameOverScreen; // voeg dit toe

    private int currentIndex = 0;
    private float timer;
    private bool gameActive = false;
    private bool gameHasEnded = false;
    private float logTimer = 0f;

    void Start()
    {
        DeactivateAll();
        if (uiManager != null)
            uiManager.HideGameOver(); // <- Zet het scherm uit bij het begin
        //if (gameOverScreen != null)
            //gameOverScreen.SetActive(false);
    }

    public void StartFireflyChallenge()
    {
        gameActive = true;
        timer = gameTime;
        ActivateNextFirefly();
    }

    void Update()
    {
        if (!gameActive)
        {
            // Toon UI één keer (nu comment je dat uit)
            if (timer <= 0f && !gameHasEnded)
            {
                gameHasEnded = true;

                // Deze twee regels uitzetten zolang er geen scherm is:
                // if (uiManager != null)
                //     uiManager.ShowGameOver();

                // if (gameOverScreen != null)
                //     gameOverScreen.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            // Laat toetsen gewoon doorgaan
            if (gameHasEnded)
            {
                if (Input.GetKeyDown(KeyCode.R))
                    RestartGame();

                if (Input.GetKeyDown(KeyCode.Q))
                    QuitGame();
            }

            return;
        }

        // Actieve game logica
        timer -= Time.deltaTime;

        if (uiManager != null)
            uiManager.UpdateTimer(timer);

        if (timer <= 0f)
        {
            gameActive = false;
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
    
    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    void QuitGame()
    {
        Application.Quit();

        // Dit werkt alleen in een build, niet in de editor:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}