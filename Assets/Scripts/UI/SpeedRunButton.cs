using UnityEngine;
using System.Collections;

public class SpeedRunButton : MonoBehaviour {
    public void startSpeedRun() {
        ScreenTransition.instance.loadScene(Levels.GetLevelFromIndex(0));
        GameScore.ResetScore();
        GameScore.ScoreMode = ScoreMode.SPEEDRUN;
    }
}