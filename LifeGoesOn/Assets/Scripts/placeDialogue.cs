using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class placeDialogue : MonoBehaviour
{
    public List<Sprite> dialogs;
    public GameObject spritePrefab;
    public float space;
    public float speed = 0.005f;
    public bool enabled = false;
    private List<GameObject> texts;

    // Start is called before the first frame update
    void Start() {
        texts = new List<GameObject>();
        for (int i = 0; i < dialogs.Count; i++) {
            GameObject text = Instantiate(spritePrefab, transform);
            text.transform.position = new Vector3(space * (i + 1), 2.5f);
            text.GetComponent<SpriteRenderer>().sprite = dialogs[i];
            texts.Add(text);
        }
    }

    void Update() {
        if (enabled) {
            for (int i = 0; i < texts.Count; i++) {
                texts[i].transform.position = new Vector3(texts[i].transform.position.x + speed, texts[i].transform.position.y);
            }
        }
    }
}
