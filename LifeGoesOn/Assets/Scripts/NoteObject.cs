using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
	private int pressedState = 0;
    private KeyCode keyToPress;
	private Animator anim, shadowAnim;
    private Collider2D player;

    private void Start() {
        anim = GetComponent<Animator>();
        shadowAnim = transform.GetChild(0).GetComponent<Animator>();
    }

    public void setKeyToPress(KeyCode key) {
        this.keyToPress = key;
    }

    private void Update() {
        if (pressedState == 1) {
            //gameObject.SetActive(false);
            float distanceBetweenObjects = transform.position.x - player.transform.position.x;

            if (Input.GetKeyDown(keyToPress)) {
                if (Mathf.Abs(distanceBetweenObjects) < 0.25) {
                    GameManager.instance.PerfectHit();
                    anim.Play("clicked", 0, 0);
                    shadowAnim.Play("clicked", 0, 0);
                } else if (Mathf.Abs(distanceBetweenObjects) < 0.5) {
                    GameManager.instance.GoodHit();
                    anim.Play("clicked", 0, 0);
                    shadowAnim.Play("clicked", 0, 0);
                }
                else if (Mathf.Abs(distanceBetweenObjects) < 1.0) {
                    GameManager.instance.OkHit();
                    anim.Play("clicked", 0, 0);
                    shadowAnim.Play("clicked", 0, 0);
                }
                pressedState = 2;
            }

            if (distanceBetweenObjects <= -1.0) { pressedState = 3; }
        }

        if (pressedState == 3) { GameManager.instance.FailHit(); pressedState = 2; }
    }

    public void EndAnim() {
        gameObject.SetActive(false);
    }


    // detect if the player object is in the hitbox area, if so, player can press the key
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            player = other;
            pressedState = 1;
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && canBePressed) {
        }
    }*/
}
