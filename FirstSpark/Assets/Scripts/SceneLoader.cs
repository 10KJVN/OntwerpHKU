using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        // Load the outside world additively at runtime
        SceneManager.LoadSceneAsync("Outside World V2", LoadSceneMode.Additive);
    }
}