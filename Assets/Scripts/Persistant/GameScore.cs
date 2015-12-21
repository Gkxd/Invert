using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameScore : MonoBehaviour {

    public static GameScore instance;

    public static bool ScoreValid { get; set; }
    public static int NumberOfDeaths { get { if (instance) return instance.numberOfDeaths; return 0; } }
    public static float TimeTaken { get { if (instance) return Time.time - instance.startTime; return 0; } }
    public static int SecretsFound { get { if (instance) return instance.secretsFound.Count; return 0; } }

    private float startTime;
    private int numberOfDeaths;
    private List<int> secretsFound;
    private List<string> unlockedLevels;

    void Awake() {
        DontDestroyOnLoad(this);

        secretsFound = new List<int>();
        unlockedLevels = new List<string>();

        if (!instance) {
            instance = this;
        }
    }

    public static void ResetScore() {
        if (instance) {
            instance.startTime = Time.time;
            instance.numberOfDeaths = 0;
        }
    }

    public static void AddDeath() {
        if (instance) {
            instance.numberOfDeaths++;
        }
    }

    public static void AddSecret(int secretID) {
        if (instance) {
            if (!instance.secretsFound.Contains(secretID)) {
                instance.secretsFound.Add(secretID);
            }
        }
    }

    public static void UnlockLevel(string level) {
        if (instance) {
            if (!instance.unlockedLevels.Contains(level)) {
                instance.unlockedLevels.Add(level);
            }
        }
    }

    public static bool LevelUnlocked(string level) {
        if (instance) {
            return instance.unlockedLevels.Contains(level);
        }
        return false;
    }

    public static void SaveAsString() {

    }

    public static void ParseFromString() {

    }
}
