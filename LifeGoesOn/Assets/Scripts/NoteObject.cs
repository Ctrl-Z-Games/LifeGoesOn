using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
	private bool canBePressed = false;
    private KeyCode keyToPress;
	//public Animator anim;

    public void setKeyToPress(KeyCode key) {
        this.keyToPress = key;
    }
    private void Update() {
        if (Input.GetKeyDown(keyToPress) && canBePressed) {
            gameObject.SetActive(false);
        }
    }

    // detect if the player object is in the hitbox area, if so, player can press the key
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player") {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && canBePressed) {
            float distanceBetweenObjects = transform.position.x - other.transform.position.x;

            if (Mathf.Abs(distanceBetweenObjects) < 0.25) {
                GameManager.instance.PerfectHit();
            } else if (Mathf.Abs(distanceBetweenObjects) < 0.5) {
                GameManager.instance.GoodHit();
            } else if (Mathf.Abs(distanceBetweenObjects) < 1.0) {
                GameManager.instance.OkHit();
            } else {
                GameManager.instance.FailHit();
            }
            canBePressed = false;
        }
    }
}
