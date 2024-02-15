using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testButtonPress : MonoBehaviour
{
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            count = 5;
        }

        if (count-- < 0) { count =  0; }
    }
}
