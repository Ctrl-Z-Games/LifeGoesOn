using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
	public bool canBePressed;
    
	public KeyCode keyToPress;
    public GameObject player;

	private float distanceBetweenObjects;

	public Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {	
	            anim.Play("Beat");	
                distanceBetweenObjects = transform.position.x - player.transform.position.x;
				//gameObject.SetActive(false);
                
                // if the x distance between the player and the note is less than 0.5, then it's a perfect hit
                if (Mathf.Abs(distanceBetweenObjects) < 0.25)
                {
                    
					anim.Play("Perfect");
					Debug.Log("Perfect Hit"); // replace with perfect hit animation
                    //currentScore += scorePerPerfectNote;
	
					// after the animation is done, set the gameobject to inactive
					
                } 
                else if (Mathf.Abs(distanceBetweenObjects) < 0.5)
                {
                    anim.Play("Good");
					//gameObject.SetActive(false);
					Debug.Log("Good Hit"); // replace with good hit animation
                    //currentScore += scorePerGoodNote;
                } else
                {
	                anim.Play("OK");	
                    //gameObject.SetActive(false);
					Debug.Log("OK Hit"); // replace with ok hit animation
                    //currentScore += scorePerOKNote;
                }
            } 
        }
    }
    
    // detect if the player object is in the hitbox area, if so, player can press the key
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canBePressed = false;
            Debug.Log("Missed Note"); // replace with missed note animation
			//
			
	
			
        }
    }
}
