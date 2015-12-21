using UnityEngine;
using System.Collections;

public class ToggleGameUI : MonoBehaviour {
    public static ToggleGameUI instance;
    public static bool IsGamePaused { get { if (instance) return instance.paused; return false; } }

    public GameUIBackground background;

    public SlideGameUI mainPauseUI;
    public SlideGameUI optionsUI;

    private bool paused;

    void Start() {
        instance = this;
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused = !paused) { // Turn UI on
                background.targetColor = new Color(1, 1, 1, 0.5f);
                mainPauseUI.slideOnscreen();
            }
            else { // Turn UI off
                background.targetColor = new Color(1, 1, 1, 0);

                mainPauseUI.slideOffscreen();
                optionsUI.slideOffscreen();
            }
        }
	}

    public void deactivateUI() {
        paused = false;
        background.targetColor = new Color(1, 1, 1, 0);

        mainPauseUI.slideOffscreen();
        optionsUI.slideOffscreen();
    }
}
