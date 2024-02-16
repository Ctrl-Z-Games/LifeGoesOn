using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class placeInMap : MonoBehaviour
{
    public float horizontalSpaceMod;
    public TextAsset mapFile;
    public GameObject hitboxPrefab1;
    public GameObject hitboxPrefab2;
    private string map = "0";

    // Start is called before the first frame update
    void Start() {
        map = mapFile.text; // read from txt file
        for (int i = 0; i < map.Length; i++) {
            int mapCode = int.Parse(map[i].ToString());
            switch (mapCode) { // instantiates new hitbox and set it's position
                case 0:
                    break;
                case 1: // bottom
                    Instantiate(hitboxPrefab1, transform).transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 0.0f);
                    break;
                case 2: // top
                    Instantiate(hitboxPrefab2, transform).transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 2.0f);
                    break;
                case 3: // both
                    Instantiate(hitboxPrefab1, transform) // instantiate new hitbox and set it's position
                        .transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 0.0f);
                    Instantiate(hitboxPrefab2, transform) // instantiate new hitbox and set it's position
                        .transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 2.0f);
                    break;
            }
        }
    }
}
