using UnityEngine;

public class NoteCollision : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            DetectCollision(1);
        }
    }

    private void DetectCollision(int noteType) { //  detects collision when key is pressed. notetype determains which type of note
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2, transform.right, 0, 8);
        if (hit) {
            NoteObject note = hit.collider.gameObject.GetComponent<NoteObject>();
            float dist = Mathf.Abs(note.transform.position.x - transform.position.x);
            if (note.noteType == noteType && !note.clicked) {
                ScoreHit(dist);
                note.ClickedAnim();
                note.clicked = true;
            }
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
