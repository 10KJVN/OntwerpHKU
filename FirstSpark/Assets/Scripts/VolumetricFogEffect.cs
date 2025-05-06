using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable, VolumeComponentMenu("Custom/VolumetricFogEffect")]
public class VolumetricFogEffect : VolumeComponent, IPostProcessComponent
{
    public ClampedFloatParameter stepSize = new ClampedFloatParameter(1f, 0.1f, 20f);
    public FloatParameter maxDistance = new FloatParameter(100f);
    public ColorParameter fogColor = new ColorParameter(Color.white, true);
    public FloatParameter densityMultiplier = new ClampedFloatParameter(1f, 0f, 10f);
    public FloatParameter noiseOffset = new FloatParameter(0f);
    public TextureParameter fogNoise = new TextureParameter(null);
    public FloatParameter noiseTiling = new FloatParameter(1f);
    public FloatParameter densityThreshold = new ClampedFloatParameter(0.1f, 0f, 1f);
    public ColorParameter lightContribution = new ColorParameter(Color.white, true);
    public FloatParameter lightScattering = new ClampedFloatParameter(0.2f, 0f, 1f);

    public bool IsActive() => active && densityMultiplier.value > 0f;
    public bool IsTileCompatible() => false;
}