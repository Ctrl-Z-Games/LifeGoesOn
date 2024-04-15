using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneMusicController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip[] babyMusic;
    public AudioClip[] kidMusic;
    public AudioClip[] teenMusic;
    public AudioClip[] adultMusic;
    public AudioClip[] seniorMusic;
    void Start()
    {
        StartCoroutine(PlayAllMusic());
    }

    private IEnumerator PlayAllMusic()
    {
        string[] categories = { "baby", "kid", "teen", "adult", "senior" };
        foreach (string category in categories)
        {
            string result = PlayerPrefs.GetString(category, "neutral"); // Default to neutral
            yield return StartCoroutine(PlayMusicForCategory(category, result));
        }
    }
    private IEnumerator PlayMusicForCategory(string category, string result)
    {
        AudioClip clipToPlay = null;
        switch (category)
        {
            case "baby":
                clipToPlay = GetClipForResult(babyMusic, result);
                break;
            case "kid":
                clipToPlay = GetClipForResult(kidMusic, result);
                break;
            case "teen":
                clipToPlay = GetClipForResult(teenMusic, result);
                break;
            case "adult":
                clipToPlay = GetClipForResult(adultMusic, result);
                break;
            case "senior":
                clipToPlay = GetClipForResult(seniorMusic, result);
                break;
        }

        if (clipToPlay != null)
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();
            yield return new WaitForSeconds(clipToPlay.length); // Wait for the clip to finish
        }
    }

    private AudioClip GetClipForResult(AudioClip[] musicArray, string result)
    {
        switch (result)
        {
            case "Happy":
                return musicArray[0];
            case "Neutral":
                return musicArray[1];
            case "Sad":
                return musicArray[2];
            default:
                return musicArray[1];  // Default to neutral if result is unrecognized
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
