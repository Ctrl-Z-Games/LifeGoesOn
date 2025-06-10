using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public bool isGameActive;
    public static GameManager instance;

    [Header("Accuracy Scoring")]
    public int currentScore;
    private int OkHitScore = 1;
    private int GoodHitScore = 2;
    private int PerfectHitScore = 3;
    private int FailHitScore = -2;
    // fail are outside range
    public float OkHitRange = 1.5f;
    public float GoodHitRange = 1.0f;
    public float PerfectHitRange = 0.6f;

    [Header("Accuracy Feedback")]
    public GameObject accuracyPrefab;
    public float accuracyHeight = 2.0f;
    public Sprite fail, ok, good, perfect;

    private GameObject accuracyObj;
    private GameObject player;
    private SpriteRenderer accSR;
    private int timer;
    public AudioSource sfxSource;
    [SerializeField] private sfxObject sfx;
    private float sfxVolume = 0.1f;
    //public AudioClip[] voiceoverClips; 
    //private int voiceoverIndex = 0;
    //private bool isVoiceoverPlaying = false;
    private bool accJuice = false;
    
    public float endPosition;
    public int numHappyScenes;
    public int numNeutralScenes;    
    public int numSadScenes;
    public int happyScore; // 62 for baby
    public int neutralScore; // 31 for baby

	public string key;


    private void Awake() { // awake is called before start, and is needed in start methods
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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
                GameObject.Find("dialog").GetComponent<Animator>().Play("dialog");
                
                backgroundMusic.Play();
                
                //if (!isVoiceoverPlaying) {
                //    StartCoroutine(PlayVoiceover());
                //}
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
        
        if(player.transform.position.x > endPosition)
        {
			
            DetermineResult();

            if (instance.currentScore >= happyScore)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + numHappyScenes);
            }
            else if (instance.currentScore >= neutralScore && instance.currentScore < happyScore)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + numNeutralScenes);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + numSadScenes);
            }
            
        }
    }

    /*
    private IEnumerator PlayVoiceover()
    {
        foreach (var clip in voiceoverClips)
        {
            voiceoverSource.clip = clip;
            voiceoverSource.Play();

            // Wait for the clip to finish, then wait an additional 'gap' seconds
            yield return new WaitForSeconds(clip.length);
        }
    }
    */

	public void DetermineResult()
    {
        string result;
		if (currentScore >= happyScore)
        {
            result = "Happy";
        }
        else if (currentScore >= neutralScore)
        {
            result = "Neutral";
        }
        else
        {
            result = "Sad";
        }
		
		//string key = "Level" + currentLevel;
		PlayerPrefs.SetString(key, result);
		PlayerPrefs.Save();
		Debug.Log("Result for " + key + " is " + result);
    }

    public void OkHit()
    {
        //Debug.Log("OK Hit");
        currentScore += OkHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = ok;
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, accuracyHeight + 0.25f);
        accJuice = true;
        sfxSource.PlayOneShot(sfx.okSound, sfxVolume);
        //Debug.Log(currentScore);
    }
    public void GoodHit()
    {
        //Debug.Log("Good Hit");
        currentScore += GoodHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = good;
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, accuracyHeight + 0.25f);
        accJuice = true;
        sfxSource.PlayOneShot(sfx.goodSound, sfxVolume);
        //Debug.Log(currentScore);
    }
    public void PerfectHit()
    {
        //Debug.Log("Perfect Hit");
        currentScore += PerfectHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = perfect;
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, accuracyHeight + 0.25f);
        accJuice = true;
        sfxSource.PlayOneShot(sfx.perfectSound, sfxVolume);
        //.Log(currentScore);
    } 
    public void FailHit()
    {
        //Debug.Log("Fail Hit");
        currentScore += FailHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = fail;
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, accuracyHeight + 0.25f);
        accJuice = true;
        sfxSource.PlayOneShot(sfx.failSound, sfxVolume);
        //Debug.Log(currentScore);
    }
}
