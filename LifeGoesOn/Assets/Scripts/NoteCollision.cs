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
            Debug.Log(dist);

            if (note.noteType == noteType) {
                ScoreHit(dist);
                note.ClickedAnim();
            }
        }
    }

    private void ScoreHit(float dist) { // scores the hit of the note
        if (dist < 0.7f) {
            GameManager.instance.PerfectHit();
        } else if (dist < 1.5f) {
            GameManager.instance.GoodHit();
        } else {
            GameManager.instance.OkHit();
        }
    }
}
