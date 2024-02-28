using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
	public bool canBePressed;
	public KeyCode keyToPress;
    public GameObject player;
	private float distanceBetweenObjects;
    public GameObject fail, ok, good, perfect;
    private Vector3 yDistance = new Vector3(0, 2f, 0);
	//public Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {	
                gameObject.SetActive(false);
                
                distanceBetweenObjects = transform.position.x - player.transform.position.x;
                if (Mathf.Abs(distanceBetweenObjects) < 0.25)
                {
                    GameManager.instance.PerfectHit();
                    Instantiate(perfect, transform.position + yDistance, Quaternion.identity);
                } else if (Mathf.Abs(distanceBetweenObjects) < 0.5)
                {
                    GameManager.instance.GoodHit();
                    Instantiate(good, transform.position + yDistance, Quaternion.identity);
                } else
                {
                    GameManager.instance.OkHit();
                    Instantiate(ok, transform.position + yDistance, Quaternion.identity);
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
            gameObject.SetActive(false);
            //Instantiate(fail, transform.position + yDistance, Quaternion.identity);
            GameManager.instance.FailHit();
            
	
        }
    }
}