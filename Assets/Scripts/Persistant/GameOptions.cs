using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOptions : MonoBehaviour {

    public static GameOptions instance;

    public static int Difficulty {
        get { if (instance) return instance.difficulty; return -1; }
    }

    public static Material ColorScheme {
        get { if (instance) return instance.colorSchemes[instance.colorScheme]; return null; }
    }

    public int difficulty;
    public List<Material> colorSchemes;

    private List<int> unlockedColorSchemes; // Indices into color scheme array
    private int colorScheme; // Index into color scheme array

    void Awake() {
        DontDestroyOnLoad(this);

        if (!instance) {
            instance = this;
        }

        unlockedColorSchemes = new List<int>();
        unlockedColorSchemes.Add(0);
    }

    public static bool UnlockColorScheme(int colorSchemeID) {
        if (instance && !instance.unlockedColorSchemes.Contains(colorSchemeID)) {
            instance.unlockedColorSchemes.Add(colorSchemeID);
            instance.colorScheme = colorSchemeID;

            return true;
        }
        return false;
    }

    public static Material ToggleNextColorScheme() {
        if (instance) {
            for (int i = 1; i < instance.colorSchemes.Count; i++) {
                if (instance.unlockedColorSchemes.Contains((instance.colorScheme + i) % instance.colorSchemes.Count)) {
                    instance.colorScheme = (instance.colorScheme + i) % instance.colorSchemes.Count;
                    break;
                }
            }
            return instance.colorSchemes[instance.colorScheme];
        }
        return null;
    }
}