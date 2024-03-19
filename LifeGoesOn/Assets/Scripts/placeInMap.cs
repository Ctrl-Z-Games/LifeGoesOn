using UnityEngine;

public class placeInMap : MonoBehaviour
{
    public float horizontalSpaceMod;
    public TextAsset mapFile;
    public GameObject qHitbox, pHitbox;

    private GameObject obj;
    private string map = "0";

    // Start is called before the first frame update
    void Start() {
        map = mapFile.text; // read from txt file
        for (int i = 0; i < map.Length; i++) {
            int mapCode = int.Parse(map[i].ToString());
            switch (mapCode) { // instantiates new hitbox and set it's position
                case 0:
                    break;

                case 1: // bottom Q
                    obj = Instantiate(qHitbox, transform);
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 0.4f);
                    obj.AddComponent<NoteObject>().setKeyToPress(KeyCode.Q);
                    break;

                case 2: // top P
                    obj = Instantiate(pHitbox, transform);
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 2.0f);
                    obj.AddComponent<NoteObject>().setKeyToPress(KeyCode.P);
                    break;

                case 3: // both Q + P
                    obj = Instantiate(qHitbox, transform);
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 0.4f);
                    obj.AddComponent<NoteObject>().setKeyToPress(KeyCode.Q);

                    obj = Instantiate(pHitbox, transform);
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 2.0f);
                    obj.AddComponent<NoteObject>().setKeyToPress(KeyCode.P);
                    break;
            }
        }
    }
}
