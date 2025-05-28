using UnityEngine;

public class NoteCollision : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            DetectCollision();
        }
    }

    private void DetectCollision() {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2, transform.right, 0, 8);
        if (hit) { Debug.Log(hit); }
        else { Debug.Log("no hit"); }
    }
}
