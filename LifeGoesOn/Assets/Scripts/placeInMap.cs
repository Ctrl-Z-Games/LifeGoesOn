using UnityEngine;

public class placeInMap : MonoBehaviour
{
    [SerializeField] private float horizontalSpaceMod = 2.74f;
    [SerializeField] private TextAsset mapFile;
    [SerializeField] private GameObject qHitbox;
    [SerializeField] private GameObject qHeldStartbox;
    [SerializeField] private GameObject qHeldEndbox;
    [SerializeField] private Vector2 qHeldOffsets;
    [SerializeField] private GameObject pHitbox;
    [SerializeField] private GameObject pHeldStartbox;
    [SerializeField] private GameObject pHeldEndbox;
    [SerializeField] private Vector2 pHeldOffsets;

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

            switch (bot) {
                case 1:
                    PlaceBeat(qHitbox, 1, i, 0.4f, 0.0f);
                    break;
                case 2:
                    PlaceBeat(qHeldStartbox, 11, i, 0.4f, qHeldOffsets.x);
                    break;
                case 3:
                    PlaceBeat(qHeldEndbox, 3, i, 0.4f, qHeldOffsets.y);
                    break;
                default:
                    break;
            }

            switch (top) {
                case 1:
                    PlaceBeat(pHitbox, 2, i, 2.0f, 0.0f);
                    break;
                case 2:
                    PlaceBeat(pHeldStartbox, 12, i, 2.0f, pHeldOffsets.x);
                    break;
                case 3:
                    PlaceBeat(pHeldEndbox, 4, i, 2.0f, pHeldOffsets.y);
                    break;
                default:
                    break;
            }
        }
    }

    void PlaceBeat(GameObject hitBox, int noteType, int spacing, float vPosition, float hOffset) {
        GameObject obj = Instantiate(hitBox, transform);
        obj.layer = 3;
        obj.transform.position = transform.position + new Vector3(spacing * horizontalSpaceMod + hOffset, vPosition);
        obj.AddComponent<NoteObject>().noteType = noteType;
    }
}
