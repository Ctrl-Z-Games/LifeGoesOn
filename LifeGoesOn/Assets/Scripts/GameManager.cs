using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public bool isGameActive;
    public autoscroll playerScroll;
    public static GameManager instance;
    public int currentScore;
    public int OkHitScore = 1;
    public int GoodHitScore = 2;
    public int PerfectHitScore = 3;
    public int FailHitScore = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameActive)
        {
            if (Input.anyKeyDown)
            {
                isGameActive = true;
                //playerScroll.hasStarted = true;
                
                backgroundMusic.Play();
            }
        }
    }
    public void OkHit()
    {
        Debug.Log("OK Hit");
        currentScore += OkHitScore;
    }
    public void GoodHit()
    {
        Debug.Log("Good Hit");
        currentScore += GoodHitScore;
    }
    public void PerfectHit()
    {
        Debug.Log("Perfect Hit");
        currentScore += PerfectHitScore;
    } 
    public void FailHit()
    {
        Debug.Log("Fail Hit");
        currentScore += FailHitScore;
    }
}
