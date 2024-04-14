using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public int happy;
    public int neutral;
    public int sad;
    public Animator animator;
    void Start()
    {
        var gameManager = GameManager.Instance;
        if (gameManager.PlayedScenes.Contains(happy))
        {
            Debug.Log("Scene 7 was played.");
        }
        if (gameManager.PlayedScenes.Contains(neutral))
        {
            Debug.Log("Scene 9 was played.");
        }
        if (gameManager.PlayedScenes.Contains(sad))
        {
            Debug.Log("Scene 11 was played.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
