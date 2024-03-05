using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class placeDialogue : MonoBehaviour
{
    public List<Sprite> dialogs;
    public GameObject spritePrefab;
    public float space;

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < dialogs.Count; i++) {
            GameObject text = Instantiate(spritePrefab, transform);
            text.transform.position = new Vector3(space * (i + 1), 2.5f);
            text.GetComponent<SpriteRenderer>().sprite = dialogs[i];
        }
    }
}
