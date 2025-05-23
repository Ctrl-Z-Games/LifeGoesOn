using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
    public static ScoreDisplay instance;
    private TextMeshProUGUI scoreDisp;
    [SerializeField] private Color scoreColor;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        scoreDisp = GetComponent<TextMeshProUGUI>();
        scoreDisp.color = scoreColor;
        scoreDisp.text = "Score: 0";
    }

    public void Update() {
        scoreDisp.text = "Score: " + GameManager.instance.currentScore.ToString();
    }
}