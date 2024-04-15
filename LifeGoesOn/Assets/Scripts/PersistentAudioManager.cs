using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentAudioManager : MonoBehaviour
{
    private static PersistentAudioManager instance = null;
    private int sceneCount = 0;  // Counter for number of scene changes

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            GetComponent<AudioSource>().Play();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneCount++;
        if (sceneCount > 6)  // Check if more than six scenes have been loaded
        {
            GetComponent<AudioSource>().Stop();  // Stop the music
            Destroy(gameObject);  // Optionally destroy this object
        }
    }
}
