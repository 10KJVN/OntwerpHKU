using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    public AudioClip level1Music; // Music for "Cave - Blockout"
    public AudioClip level2Music; // Music for "Outside World"

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton pattern: Ensure only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the AudioManager between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
            return;
        }

        // Set up the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;

        // Play music for the initial scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        PlayMusicForScene(currentSceneName);

        // Register to sceneLoaded event for future transitions
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Play music based on the scene name
    public void PlayMusicForScene(string sceneName)
    {
        AudioClip clip = null;

        switch (sceneName)
        {
            case "Cave - Blockout":
                clip = level1Music;
                break;
            case "Outside World":
                clip = level2Music;
                break;
            default:
                Debug.LogWarning("No music defined for scene: " + sceneName);
                return;
        }

        if (clip != null && audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Triggered after a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }
}
