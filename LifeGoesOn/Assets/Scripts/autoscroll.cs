using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoscroll: MonoBehaviour
{
    public float speed;
    public bool hasStarted;

    // Update is called once per frame
    void FixedUpdate() {
        if (hasStarted)
        {
            transform.Translate(new Vector2(speed*0.05f, 0));
        }
        
    }
}
