using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // when press the key, the animation will play
	public Animator anim;	
	// choose a key to press
	public KeyCode keyToPress;
    
// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            anim.Play("BeatBear");
        }
		if (Input.GetKeyDown(keyToPress))
        {
            anim.Play("BeatBall");
        }
    }
}
