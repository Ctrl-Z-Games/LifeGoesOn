using UnityEngine;

public class placeInMap : MonoBehaviour
{
    public float horizontalSpaceMod;
    public TextAsset mapFile;
    public GameObject qHitbox, pHitbox, spceHitbox;

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
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 0.0f);
                    obj.GetComponent<NoteObject>().setKeyToPress(KeyCode.Q);
                    break;
                
                case 4: // bottom P
                    obj = Instantiate(pHitbox, transform);
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 0.0f, 0.02f);
                    obj.GetComponent<NoteObject>().setKeyToPress(KeyCode.P);
                    break;

                case 2: // top
                    obj = Instantiate(pHitbox, transform);
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 2.0f, 0.1f);
                    obj.GetComponent<NoteObject>().setKeyToPress(KeyCode.P);
                    break;

                case 3: // both
                    obj = Instantiate(qHitbox, transform);
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 0.0f);
                    obj.GetComponent<NoteObject>().setKeyToPress(KeyCode.Q);

                    obj = Instantiate(pHitbox, transform);
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 2.0f, 0.02f);
                    obj.GetComponent<NoteObject>().setKeyToPress(KeyCode.P);
                    break;
                
                case 6: // Space Hitbox
                    obj = Instantiate(spceHitbox, transform);
                    obj.transform.position = transform.position + new Vector3(i * horizontalSpaceMod, 2.0f);
                    obj.GetComponent<NoteObject>().setKeyToPress(KeyCode.Space); 
                    break;
            }
        }
    }
}
