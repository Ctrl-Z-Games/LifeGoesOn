using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
    private TextMeshProUGUI scoreDisp;
    [SerializeField] private Color scoreColor;

    private void Start() {
        scoreDisp = GetComponent<TextMeshProUGUI>();
        scoreDisp.color = scoreColor;
        scoreDisp.text = "Score: 0";
    }

    public void Update() {
        scoreDisp.text = "Score: " + GameManager.instance.currentScore.ToString();
    }
}