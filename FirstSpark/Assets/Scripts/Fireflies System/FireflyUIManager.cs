using UnityEngine;
using TMPro;

public class FireflyUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI fireflyText;
    [SerializeField] private GameObject gameOverScreen;

    public void UpdateTimer(float time)
    {
        timerText.text = $"Time: {Mathf.CeilToInt(time)}s";
    }

    public void UpdateFireflyCount(int collected, int total)
    {
        fireflyText.text = $"Fireflies: {collected}/{total}";
    }

    public void HideGameOver()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
    }
    
    public void ShowGameOver()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);
    }
    
    
}