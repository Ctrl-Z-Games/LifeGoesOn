using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public bool isGameActive;
    public static GameManager instance;
    public int currentScore;
    public int OkHitScore = 1;
    public int GoodHitScore = 2;
    public int PerfectHitScore = 3;
    public int FailHitScore = -1;
    public GameObject accuracyPrefab;
    public float accuracyHeight = 2.0f;
    public Sprite fail, ok, good, perfect;

    private GameObject accuracyObj;
    private GameObject player;
    private SpriteRenderer accSR;
    private int timer;
    public AudioSource voiceoverSource; 
    public AudioClip[] voiceoverClips; 
    private int voiceoverIndex = 0;
    private bool isVoiceoverPlaying = false;
    private bool accJuice = false;
    public float gap = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.Find("Player");
        accuracyObj = Instantiate(accuracyPrefab, player.transform);
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, accuracyHeight);
        accuracyObj.SetActive(false);
        accSR = accuracyObj.GetComponent<SpriteRenderer>();
        timer = 0;
        //currentScore = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameActive)
        {
            if (Input.anyKeyDown)
            {
                isGameActive = true;
                player.GetComponent<autoscroll>().hasStarted = true;
                //GetComponent<placeDialogue>().enabled = true;
                GameObject.Find("dialogs").GetComponent<Animator>().Play("dialog");
                
                backgroundMusic.Play();
                
                if (!isVoiceoverPlaying)
                {
                    StartCoroutine(PlayVoiceover());
                }
            }
        }

        if (timer++ == 100) {
            accuracyObj.SetActive(false);
            timer = 0;
        }

        if (timer == 5) {
            accJuice = false;
        }

        if (accJuice) {
            accuracyObj.transform.position -= new Vector3(0f, 0.05f);
        }
    }
    private IEnumerator PlayVoiceover()
    {
        foreach (var clip in voiceoverClips)
        {
            voiceoverSource.clip = clip;
            voiceoverSource.Play();

            // Wait for the clip to finish, then wait an additional 'gap' seconds
            yield return new WaitForSeconds(clip.length + gap);
        }
    }

    public void OkHit()
    {
        Debug.Log("OK Hit");
        currentScore += OkHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = ok;
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, accuracyHeight + 0.25f);
        accJuice = true;
        Debug.Log(currentScore);
    }
    public void GoodHit()
    {
        Debug.Log("Good Hit");
        currentScore += GoodHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = good;
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, accuracyHeight + 0.25f);
        accJuice = true;
        Debug.Log(currentScore);
    }
    public void PerfectHit()
    {
        Debug.Log("Perfect Hit");
        currentScore += PerfectHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = perfect;
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, accuracyHeight + 0.25f);
        accJuice = true;
        Debug.Log(currentScore);
    } 
    public void FailHit()
    {
        Debug.Log("Fail Hit");
        currentScore += FailHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = fail;
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, accuracyHeight + 0.25f);
        accJuice = true;
        Debug.Log(currentScore);
    }
}
