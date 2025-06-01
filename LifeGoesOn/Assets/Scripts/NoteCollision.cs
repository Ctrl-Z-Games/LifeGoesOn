using UnityEngine;

public class NoteCollision : MonoBehaviour {
    private Vector2 hitZone;

    private void Start() {
        hitZone = GameManager.instance.OkHitRange * Vector2.one;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) { DetectCollision(1); }
        if (Input.GetKeyDown(KeyCode.P)) { DetectCollision(2); }
    }

    private void DetectCollision(int noteType) { // detects collision when key is pressed. notetype determains which type of note
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, hitZone, 0f, 8);
        foreach (Collider2D hit in hits) {
            if (hit) {
                NoteObject note = hit.gameObject.GetComponent<NoteObject>();
                float dist = Mathf.Abs(note.transform.position.x - transform.position.x);
                if (note.noteType == noteType && !note.clicked) {
                    ScoreHit(dist);
                    note.ClickedAnim();
                    note.clicked = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) { // detects if a note has exited before hitting any notes
        NoteObject note = other.GetComponent<NoteObject>();
        if (note && !note.clicked) {
            GameManager.instance.FailHit();
        }
    }

    private void ScoreHit(float dist) { // scores the hit of the note
        if (dist < GameManager.instance.PerfectHitRange) {
            GameManager.instance.PerfectHit();
        } else if (dist < GameManager.instance.GoodHitRange) {
            GameManager.instance.GoodHit();
        } else {
            GameManager.instance.OkHit();
        }
    }
}
