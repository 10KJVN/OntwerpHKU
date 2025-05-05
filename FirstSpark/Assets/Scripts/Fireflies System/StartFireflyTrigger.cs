using UnityEngine;

public class StartFireflyTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (other.CompareTag("Player"))
        {
            triggered = true;
            FireflyManager manager = FindObjectOfType<FireflyManager>();
            manager.StartFireflyChallenge();
        }
    }
}