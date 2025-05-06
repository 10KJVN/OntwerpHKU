using UnityEngine;

public class MistController : MonoBehaviour
{
    public Material mistMaterial;

    private float timer = 0f;
    private float duration = 3f;
    private bool fading = false;

    public void StartFade()
    {
        fading = true;
    }

    void Update()
    {
        if (!fading) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);

        mistMaterial.SetFloat("_DensityMultiplier", Mathf.Lerp(1f, 0.5f, t));
        mistMaterial.SetFloat("_DensityThreshold", Mathf.Lerp(0.2f, 0.9f, t));
        mistMaterial.SetFloat("_NoiseTiling", Mathf.Lerp(1f, 5f, t));
        mistMaterial.SetFloat("_StepSize", Mathf.Lerp(1f, 2f, t));
        mistMaterial.SetFloat("_MaxDistance", Mathf.Lerp(50f, 100f, t));
        mistMaterial.SetFloat("_LightScattering", Mathf.Lerp(0.3f, 1f, t));
    }
}