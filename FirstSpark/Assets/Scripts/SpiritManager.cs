using UnityEngine;

public class SpiritManager : MonoBehaviour
{
    public static SpiritManager Instance;
    private int spiritsFound = 0;
    public int requiredSpirits = 5;
    public GameObject mistBarrier;
    public GameObject playerGlow;

    private void Awake() => Instance = this;

    public void SpiritFound()
    {
        spiritsFound++;
        if (spiritsFound >= requiredSpirits)
        {
            mistBarrier.SetActive(false); // of fade out
            playerGlow.SetActive(true);   // emissive glow object/FX
        }
    }
}

