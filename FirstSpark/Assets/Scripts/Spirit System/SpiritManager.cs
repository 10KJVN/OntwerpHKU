using UnityEngine;

public class SpiritManager : MonoBehaviour
{
    public static SpiritManager Instance;
    private int spiritsFound = 0;
    public int requiredSpirits = 5;
    public GameObject mistBarrier;
    public GameObject playerGlow;

    private MistController mistController;

    private void Awake()
    {
        Instance = this;
        if (mistBarrier != null)
            mistController = mistBarrier.GetComponent<MistController>();
    }

    public void SpiritFound()
    {
        spiritsFound++;
        if (spiritsFound >= requiredSpirits)
        {
            playerGlow.SetActive(true); // emissive glow op borst

            if (mistController != null)
            {
                mistController.StartFade(); // fade de shader uit
                // Optioneel: Destroy na fade
                Destroy(mistBarrier, 4f);
            }
            else
            {
                mistBarrier.SetActive(false); // fallback als mistController mist
            }
        }
    }
}