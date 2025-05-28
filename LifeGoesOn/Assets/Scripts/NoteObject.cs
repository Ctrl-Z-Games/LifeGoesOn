using Unity.VisualScripting;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
	//private int pressedState = 0;
    //private KeyCode keyToPress;
    //private KeyCode bannedKey = KeyCode.Escape;
	private Animator anim, shadowAnim;
    private SpriteRenderer sr;
    public int noteType;
    public bool clicked = false;
    private Collider2D player;
    
    private void Start() {
        anim = GetComponent<Animator>();
        shadowAnim = transform.GetChild(0).GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0.8f, 0.8f, 0.8f, 0.65f);
    }

    public void Update() {
        if (player) {
            float dist = Mathf.Abs(transform.position.x - player.transform.position.x);
            if (dist < GameManager.instance.PerfectHitRange) { sr.color = Color.white; }
            else if (dist < GameManager.instance.GoodHitRange) { sr.color = 0.9f * Color.white; }
            else if (dist <= GameManager.instance.OkHitRange) { sr.color = new Color(0.8f, 0.8f, 0.8f, 0.75f); }
            else {
                GameManager.instance.FailHit();
                clicked = true;
                player = null;
            }
        }
    }

    /* OLD COLLISION LOGIC
    public void setKeyToPress(KeyCode key, KeyCode banned = KeyCode.Escape) {
        keyToPress = key;
        bannedKey = banned;
    }

    private void Update() {
        if (pressedState == 1) {
            //gameObject.SetActive(false);
            float distanceBetweenObjects = transform.position.x - player.transform.position.x;

            if (Input.GetKeyDown(keyToPress) && !Input.GetKeyDown(bannedKey)) {
                if (Mathf.Abs(distanceBetweenObjects) < 0.25) {
                    GameManager.instance.PerfectHit();
                } else if (Mathf.Abs(distanceBetweenObjects) < 0.5) {
                    GameManager.instance.GoodHit();
                }
                else if (Mathf.Abs(distanceBetweenObjects) < 1.0) {
                    GameManager.instance.OkHit();
                }
                pressedState = 2;
                anim.Play("clicked", 0, 0);
                shadowAnim.Play("clicked", 0, 0);
            }

            if (Input.GetKeyDown(bannedKey)) {
                pressedState = 3;
            }

            if (distanceBetweenObjects <= -1.0) { pressedState = 3; }
        }

        if (pressedState == 3) { GameManager.instance.FailHit(); pressedState = 2; }
    }
    */

    public void ClickedAnim() {
        anim.Play("clicked", 0, 0);
        shadowAnim.Play("clicked", 0, 0);
    }

    public void EndAnim() {
        gameObject.SetActive(false);
    }

    // detect if the player object is in the hitbox area, if so, player can press the key
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            player = other;
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && canBePressed) {
        }
    }*/
}
