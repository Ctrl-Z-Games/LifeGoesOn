using UnityEngine;

public class placeInMap : MonoBehaviour
{
    public float horizontalSpaceMod = 2.74f;
    public TextAsset mapFile;
    public GameObject qHitbox, pHitbox;

    private GameObject obj;

    // Start is called before the first frame update
    void Start() {
        string[] map = mapFile.text.Split(new[] { "\r", "\n"}, System.StringSplitOptions.RemoveEmptyEntries); // read from txt file
        for (int i = 0; i < map.Length; i++) {
            switch (map[i].Trim()) { // instantiates new hitbox and set it's position
                case "00":
                    break;

                case "10": // bottom Q
                    obj = Instantiate(qHitbox, transform);
                    obj.layer = 3;
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 0.4f);
                    obj.AddComponent<NoteObject>().noteType = 1;
                    break;

                case "01": // top P
                    obj = Instantiate(pHitbox, transform);
                    obj.layer = 3;
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 2.0f);
                    obj.AddComponent<NoteObject>().noteType = 2;
                    break;

                case "11": // both Q + P
                    obj = Instantiate(qHitbox, transform);
                    obj.layer = 3;
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 0.4f);
                    obj.AddComponent<NoteObject>().noteType = 1;

                    obj = Instantiate(pHitbox, transform);
                    obj.layer = 3;
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 2.0f);
                    obj.AddComponent<NoteObject>().noteType = 2;
                    break;
            }
        }
    }
}
