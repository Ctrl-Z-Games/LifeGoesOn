using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 1f; 
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeTime); 
    }
}
