using UnityEngine;

public class FireflyPickup : MonoBehaviour
{
    public ParticleSystem collectEffect;
    public AudioClip collectSound;

    private FireflyManager manager;

    private void Start()
    {
        manager = FindObjectOfType<FireflyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //RespawnManager.Instance.UpdateCheckpoint(transform.position);
            //Destroy(gameObject);
            
            if (collectEffect != null)
                Instantiate(collectEffect, transform.position, Quaternion.identity);

            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            manager.FireflyCollected();
        }
    }
}