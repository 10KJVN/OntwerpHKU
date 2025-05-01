using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LightingStateManager : MonoBehaviour
{
    public Volume globalVolume;

    public VolumeProfile litProfile;
    public VolumeProfile darkProfile;
    public VolumeProfile restoredProfile;

    public enum LightingState { Lit, Dark, Restored }
    private LightingState currentState;

    public void SetState(LightingState state)
    {
        currentState = state;
        switch (state)
        {
            case LightingState.Lit:
                globalVolume.profile = litProfile;
                break;
            case LightingState.Dark:
                globalVolume.profile = darkProfile;
                break;
            case LightingState.Restored:
                globalVolume.profile = restoredProfile;
                break;
        }
    }

    // Voor test: toggle op toetsen
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetState(LightingState.Lit);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetState(LightingState.Dark);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetState(LightingState.Restored);
    }
}