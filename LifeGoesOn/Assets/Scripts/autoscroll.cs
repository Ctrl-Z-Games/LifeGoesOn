using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoscroll: MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update() {
        transform.Translate(new Vector2(speed, 0));
    }
}
