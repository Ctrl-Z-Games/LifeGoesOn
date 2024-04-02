using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceoverManager : MonoBehaviour
{
    public AudioClip[] voiceoverClips; // Assign this in the inspector with your clips
    public float gap = 2f; // The gap in seconds between clips

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayVoiceoversSequentially());
    }
    IEnumerator PlayVoiceoversSequentially()
    {
        foreach (var clip in voiceoverClips)
        {
            audioSource.clip = clip;
            audioSource.Play();

            // Wait for the clip to finish, then wait an additional 'gap' seconds
            yield return new WaitForSeconds(clip.length + gap);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
