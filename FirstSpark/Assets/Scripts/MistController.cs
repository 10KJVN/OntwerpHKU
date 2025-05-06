using UnityEngine;

public class MistController : MonoBehaviour
{
    public Material mistMaterial;

    private float timer = 0f;
    private float duration = 3f;
    private bool fading = false;

    private void Start()
    {
        ResetMistSettings(); // Reset mist settings bij levelstart
    }

    public void StartFade()
    {
        fading = true;
        timer = 0f;
    }

    void Update()
    {
        if (!fading) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);

        mistMaterial.SetFloat("_DensityMultiplier", Mathf.Lerp(0.15f, 0.5f, t));
        mistMaterial.SetFloat("_DensityThreshold", Mathf.Lerp(0.276f, 0.9f, t));
        mistMaterial.SetFloat("_NoiseTiling", Mathf.Lerp(0.5f, 5f, t));
        mistMaterial.SetFloat("_StepSize", Mathf.Lerp(1.5f, 2f, t));
        mistMaterial.SetFloat("_MaxDistance", Mathf.Lerp(60f, 100f, t));
        mistMaterial.SetFloat("_LightScattering", Mathf.Lerp(0.15f, 1f, t));
    }

    public void ResetMistSettings()
    {
        mistMaterial.SetFloat("_DensityMultiplier", 0.15f);
        mistMaterial.SetFloat("_DensityThreshold", 0.276f);
        mistMaterial.SetFloat("_NoiseTiling", 0.5f);
        mistMaterial.SetFloat("_StepSize", 1.5f);
        mistMaterial.SetFloat("_MaxDistance", 60f);
        mistMaterial.SetFloat("_LightScattering", 0.175f);
    }
}