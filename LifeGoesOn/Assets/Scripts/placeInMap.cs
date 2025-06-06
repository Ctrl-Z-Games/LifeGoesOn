using UnityEngine;

public class placeInMap : MonoBehaviour
{
    public float horizontalSpaceMod = 2.74f;
    public TextAsset mapFile;
    public GameObject qHitbox, pHitbox;

    private GameObject obj;

    // Start is called before the first frame update
    void Start() {
        string[] map = mapFile.text.Split(new[] {"\r", "\n"}, System.StringSplitOptions.RemoveEmptyEntries); // read from txt file
        for (int i = 0; i < map.Length; i++) {
            string block = map[i].Trim();

            if (block.Length != 2) {
                Debug.LogWarning($"Bad block {block} at index {i}");
                return;
            }
            int bot = block[0] - '0';
            int top = block[1] - '0';

            if (bot == 1) {
                PlaceBeat(qHitbox, 1, i, 0.4f);
            }

            if (top == 1) {
                PlaceBeat(pHitbox, 2, i, 2.0f);
            }
        }
    }

    void PlaceBeat(GameObject hitBox, int noteType, int spacing, float vPosition) {
        obj = Instantiate(hitBox, transform);
        obj.layer = 3;
        obj.transform.position = transform.position + new Vector3(spacing * horizontalSpaceMod, vPosition);
        obj.AddComponent<NoteObject>().noteType = noteType;
    }
}
