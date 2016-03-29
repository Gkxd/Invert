using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public static class Levels {
    private static string[] levelNames = {
        "Level_A1",
        "Level_A2",
        "Level_A3",
        "Level_A4",
        "Level_A5",
        "Level_B1",
        "Level_B2",
        "Level_B3",
        //"Level_B4",
        //"Level_B5",
        "Level_C1",
        "Level_C2",
        "Level_C3",
        "Level_C4",
        "Level_C5",
        "Level_D1",
        "Level_D2",
        "Level_D3",
        "Level_D4",
        "Level_D5",
    };

    public static string GetLevelFromIndex(int level) {
        return levelNames[level];
    }

    public static string GetNextLevel(string currentLevel) {
        for (int i = 0; i < levelNames.Length; i++) {
            if (levelNames[i] == currentLevel) {
                if (i == levelNames.Length - 1) {
                    return "Win Screen"; // Todo: Create different win screens for speedrun and normal mode
                }
                else {
                    return levelNames[i + 1];
                }
            }
        }
        return "Title Screen";
    }
}

public class Goal : MonoBehaviour {
    public enum GoalType {
        NORMAL, SECRET, UI
    }

    public GameObject soundEffectPrefab;
    public GoalType goalType = GoalType.NORMAL;

    public string destination;

    private bool activated = false;
    private string levelName;

    void Start() {
        levelName = SceneManager.GetActiveScene().name;
    }

    void OnTriggerStay(Collider other) {
        if (!activated) {
            switch (goalType) {
                case GoalType.NORMAL:
                    if (destination != "") { // If destination is set, then this is a special room
                        ScreenTransition.instance.loadScene(destination);
                    }
                    else {
                        GameScore.CompleteLevel(levelName);
                        ScreenTransition.instance.loadScene(Levels.GetNextLevel(levelName));
                    }
                    break;
                case GoalType.SECRET:
                    GameScore.CompleteLevel(levelName);

                    if (GameScore.ScoreMode == ScoreMode.SPEEDRUN) {
                        ScreenTransition.instance.loadScene(Levels.GetNextLevel(levelName));
                    }
                    else {
                        ScreenTransition.instance.loadScene(destination);
                    }
                    break;
                case GoalType.UI:
                    if (destination == "") {
                        ScreenTransition.instance.loadScene("Title Screen");
                    }
                    else {
                        ScreenTransition.instance.loadScene(destination);
                    }
                    break;
            }

            Instantiate(soundEffectPrefab);

            activated = true;
        }
    }
}
