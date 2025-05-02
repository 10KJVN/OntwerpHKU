using UnityEngine;
using TMPro;

public class FireflyUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI fireflyText;

    public void UpdateTimer(float time)
    {
        timerText.text = $"Time: {Mathf.CeilToInt(time)}s";
    }

    public void UpdateFireflyCount(int collected, int total)
    {
        fireflyText.text = $"Fireflies: {collected}/{total}";
    }
}