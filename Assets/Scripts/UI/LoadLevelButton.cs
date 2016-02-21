using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

    public ScaleButtonWithMouse scaleButtonWithMouse;
    public Button button;
    public Text text;

    public int levelIndex;

    void Start() {
        if (!(levelIndex == 0 || GameScore.IsLevelComplete(levelIndex - 1))) {
            scaleButtonWithMouse.enabled = false;
            button.enabled = false;
            text.color = new Color(0, 0, 0, 0.1f);
        }
    }

    // Editor Convenience
    void Reset() {
        scaleButtonWithMouse = GetComponent<ScaleButtonWithMouse>();
        button = GetComponent<Button>();
        text = transform.Find("Text").GetComponent<Text>();
    }

    // Called On Button Click
    public void loadLevel() {
        ScreenTransition.instance.loadScene(Levels.GetLevelFromIndex(levelIndex));
        GameScore.ResetScore();
        GameScore.ScoreMode = ScoreMode.LEVEL;
    }
}
