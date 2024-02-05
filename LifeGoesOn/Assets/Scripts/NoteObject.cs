using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                //GameManager.instance.NoteHit();
                if (Math.Abs(transform.position.x) > 0.25f)
                {
                    ScoreNote.instance.NormalHit();
                }
                else if (Math.Ab s(transform.position.x) > 0.05f)     
                {
                    ScoreNote.instance.GoodHit();
                }
                else
                {
                    ScoreNote.instance.PerfectHit();
                }
            }
        }
    }
}
