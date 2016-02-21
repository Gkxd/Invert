using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ScoreMode {
    SPEEDRUN, LEVEL
}
public class GameScore : MonoBehaviour {

    public static GameScore instance;

    public static ScoreMode ScoreMode;
    public static int NumberOfDeaths { get { if (instance) return instance.numberOfDeaths; return 0; } }
    public static float TimeTaken { get { if (instance) return Time.time - instance.startTime; return 0; } }
    public static int SecretsFound { get { if (instance) return instance.secretsFound.Count; return 0; } }
    public static int CompletionScore { get { if (instance) return instance.completedLevels.Count + instance.secretsFound.Count; return 0; } }

    private float startTime;
    private int numberOfDeaths;
    private List<int> secretsFound;
    private List<string> completedLevels;

    private bool saveOnExit;

    void Awake() {
        DontDestroyOnLoad(this);

        secretsFound = new List<int>();
        completedLevels = new List<string>();

        if (!instance) {
            instance = this;
        }

        LoadFromString();
        saveOnExit = true;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.DeleteAll();
            saveOnExit = false;
            Application.Quit();
        }
    }

    void OnApplicationQuit() {
        if (saveOnExit) {
            SaveAsString();
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
                Notification.NotifySecretFound();
            }
        }
    }

    public static void CompleteLevel(string level) {
        if (instance) {
            if (!instance.completedLevels.Contains(level)) {
                instance.completedLevels.Add(level);
            }
        }
    }

    public static bool IsLevelComplete(int levelIndex) {
        if (instance) {
            return instance.completedLevels.Contains(Levels.GetLevelFromIndex(levelIndex));
        }
        return false;
    }


    public static void SaveAsString() {
        string gameData = "Version 1\n";
        foreach (string s in instance.completedLevels) {
            if (s == "") continue;
            gameData += s + ",";
        }
        gameData += "\n";

        foreach (int i in instance.secretsFound) {
            gameData += i + ",";
        }
        gameData += "\n";

        foreach (int i in GameOptions.instance.unlockedColorSchemes) {
            gameData += i + ",";
        }
        gameData += "\n";

        gameData += GameOptions.instance.colorScheme;


        Debug.Log("Saving gameData:\n" + gameData);

        PlayerPrefs.SetString("gameData", gameData);
        PlayerPrefs.Save();
    }

    public static void LoadFromString() {
        string gameData = PlayerPrefs.GetString("gameData");
        Debug.Log("Loading gameData:\n" + gameData);

        string[] data = gameData.Split('\n');

        if (data.Length != 5 || data[0] != "Version 1") {
            Debug.Log("No Valid Save Data Found");
            return;
        }

        string[] completedLevels = data[1].Split(',');

        foreach (string s in completedLevels) {
            if (s == "") continue;
            instance.completedLevels.Add(s);
        }

        string[] secretsFound = data[2].Split(',');
        foreach (string s in secretsFound) {
            if (s == "") continue;
            instance.secretsFound.Add(int.Parse(s));
        }

        string[] colorSchemesUnlocked = data[3].Split(',');
        foreach (string s in colorSchemesUnlocked) {
            if (s == "" || s == "0") continue;
            GameOptions.instance.unlockedColorSchemes.Add(int.Parse(s));
        }

        GameOptions.instance.colorScheme = int.Parse(data[4]);
    }
}
