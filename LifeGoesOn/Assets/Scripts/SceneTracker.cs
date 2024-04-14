using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public int happy;
    public int neutral;
    public int sad;
    public Animator animator;
    public HashSet<int> playedScenes = new HashSet<int>();
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Start()
    {
        animator = GetComponent<Animator>(); 
        RecordScenePlayed();
        
        if(playedScenes.Contains(happy))
        {
            animator.Play("Happy");
        }
        else if(playedScenes.Contains(neutral))
        {
            animator.Play("Neutral");
        }
        else if(playedScenes.Contains(sad))
        {
            animator.Play("Sad");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        RecordScenePlayed();
    }
    public void RecordScenePlayed()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        playedScenes.Add(sceneIndex);
        Debug.Log("Scene " + sceneIndex + " has been played");
        
    }
    
}
