using UnityEngine;

public class FireController : MonoBehaviour
{
    public ParticleSystem fireParticles;
    public Light fireLight;
    public AudioSource fireAudio;
    public float timeUntilExtinguish = 10f;
    private float timer;
    private bool isExtinguished;

    void Update()
    {
        if (isExtinguished) return;

        timer += Time.deltaTime;
        if (timer >= timeUntilExtinguish)
            ExtinguishFire();
    }

    void ExtinguishFire()
    {
        fireParticles.Stop();
        fireLight.enabled = false;
        fireAudio.Stop();
        isExtinguished = true;
        // Optional: trigger een doel of hint voor speler
    }
}
