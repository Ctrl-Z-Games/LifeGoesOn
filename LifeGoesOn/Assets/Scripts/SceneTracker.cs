using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int currentSceneID = SceneManager.GetActiveScene().buildIndex;
        GameManager.Instance.RecordScenePlayed(currentSceneID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
