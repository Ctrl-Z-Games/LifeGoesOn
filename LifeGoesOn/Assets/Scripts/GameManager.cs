using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource neutralMusic;
    public AudioSource happyMusic;
    public AudioSource sadMusic;
    public bool isGameActive;
    public static GameManager instance;
    public int currentScore;
    public int OkHitScore = 1;
    public int GoodHitScore = 2;
    public int PerfectHitScore = 3;
    public int FailHitScore = -1;
    public GameObject accuracyPrefab;
    public Sprite fail, ok, good, perfect;

    private GameObject accuracyObj;
    private GameObject player;
    private SpriteRenderer accSR;
    private int timer;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.Find("Player");
        accuracyObj = Instantiate(accuracyPrefab, player.transform);
        accuracyObj.transform.position = player.transform.position + new Vector3(0f, 2f);
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
                
                neutralMusic.Play();
                //happyMusic.Play();
                //sadMusic.Play();
            }
        }

        if (timer++ == 300) {
            accuracyObj.SetActive(false);
            timer = 0;
        }
    }

    public void OkHit()
    {
        Debug.Log("OK Hit");
        currentScore += OkHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = ok;
        currentScore += OkHitScore;
        Debug.Log(currentScore);
    }
    public void GoodHit()
    {
        Debug.Log("Good Hit");
        currentScore += GoodHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = good;
        currentScore += GoodHitScore;
        Debug.Log(currentScore);
    }
    public void PerfectHit()
    {
        Debug.Log("Perfect Hit");
        currentScore += PerfectHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = perfect;
        currentScore += PerfectHitScore;
        Debug.Log(currentScore);
    } 
    public void FailHit()
    {
        Debug.Log("Fail Hit");
        currentScore += FailHitScore;
        accuracyObj.SetActive(true);
        timer = 0;
        accSR.sprite = fail;
        currentScore += FailHitScore;
        Debug.Log(currentScore);
    }
}
