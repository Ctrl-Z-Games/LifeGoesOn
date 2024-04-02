using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BabySceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float endPosition;
    public int numScenes;
    public static GameManager instance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > endPosition)
        {
            //if (instance.currentScore >= 10)
            //{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + numScenes);
            //}
            
        }
    }
}
