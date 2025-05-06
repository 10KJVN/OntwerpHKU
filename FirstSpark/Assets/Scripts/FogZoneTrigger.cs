using UnityEngine;

public class FogToggleTrigger : MonoBehaviour
{
    [Tooltip("Drag hier je volumetric fog materiaal in.")]
    public Material fogMaterial;

    [Tooltip("Zet aan of uit afhankelijk van deze zone.")]
    public bool enableFog = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && fogMaterial != null)
        {
            fogMaterial.SetFloat("_FogEnabled", enableFog ? 1f : 0f);
        }
    }
}