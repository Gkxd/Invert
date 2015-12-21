using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

    public ScaleButtonWithMouse scaleButtonWithMouse;
    public Button button;
    public Text text;

    public string levelName;

    void Start() {
        if (!GameScore.LevelUnlocked(levelName)) {
            scaleButtonWithMouse.enabled = false;
            button.enabled = false;
            text.color = new Color(0, 0, 0, 0.1f);
        }
    }

    void Reset() {
        scaleButtonWithMouse = GetComponent<ScaleButtonWithMouse>();
        button = GetComponent<Button>();
        text = transform.Find("Text").GetComponent<Text>();
    }

    public void loadLevel() {
        ScreenTransition.instance.loadScene(levelName);
        GameScore.ResetScore();
        GameScore.ScoreValid = false;
    }
}
