using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameScore : MonoBehaviour {
    public bool resetData;

    public static GameScore instance;

    public static bool ScoreValid { get; set; }
    public static int NumberOfDeaths { get { if (instance) return instance.numberOfDeaths; return 0; } }
    public static float TimeTaken { get { if (instance) return Time.time - instance.startTime; return 0; } }
    public static int SecretsFound { get { if (instance) return instance.secretsFound.Count; return 0; } }

    private float startTime;
    private int numberOfDeaths;
    private List<int> secretsFound;
    private List<string> unlockedLevels;

    private bool saveOnExit;

    void Awake() {
        DontDestroyOnLoad(this);

        secretsFound = new List<int>();
        unlockedLevels = new List<string>();

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
        string gameData = "Version 1\n";
        foreach (string s in instance.unlockedLevels) {
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

        string[] unlockedLevels = data[1].Split(',');

        foreach (string s in unlockedLevels) {
            if (s == "") continue;
            instance.unlockedLevels.Add(s);
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
