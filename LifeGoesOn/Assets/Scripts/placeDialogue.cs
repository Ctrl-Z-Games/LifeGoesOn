using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class placeDialogue : MonoBehaviour
{
    public string folderPath;
    public string levelName;
    public GameObject spritePrefab;
    public float space;

    // Start is called before the first frame update
    void Start() {
        int numDialogues = Directory.GetFiles(folderPath, "*.png").Length;

        for (int i = 1; i <= numDialogues; i++) {
            Texture2D texture = new(2, 2); // dummy value
            byte[] fileData = File.ReadAllBytes(Path.Combine(folderPath, levelName + "Text" + i.ToString()) + ".png");
            texture.LoadImage(fileData);

            GameObject text = Instantiate(spritePrefab, transform);
            text.transform.position = new Vector3(space * i, 2.5f);
            text.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}
