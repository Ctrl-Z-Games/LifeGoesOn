using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score : MonoBehaviour
{
	public int currentScore;
	public int scorePerNote = 100; // 100 points per note bydefault
	public int scorePerGoodNote = 125;
	public int scorePerPerfectNote = 150;
	public int scorePerFailedNote = 50; // 
	//public int currentMultiplier;
	//public int multiplierTracker;
	//public int[] multiplierThresholds;
	
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
		//currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void NoteHit()
    {
        Debug.Log("Hit On Time");
        currentScore += scorePerNote; //* currentMultiplier; 
    }

	public void GoodNoteHit()
    {
        NoteHit();
	    currentScore += scorePerGoodNote;//* currentMultiplier;
    }
	public void PerfectNoteHit()
    {
        NoteHit();
		currentScore += scorePerPerfectNote; //* currentMultiplier;
    }
	public void NoteMissed()
    {
	    Debug.Log("Missed Note");
        currentScore -= scorePerFailedNote;
    }	

}
