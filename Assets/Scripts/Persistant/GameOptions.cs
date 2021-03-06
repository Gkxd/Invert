﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOptions : MonoBehaviour {

    public static GameOptions instance;

    public static int Difficulty {
        get { if (instance) return instance.difficulty; return -1; }
        set { if (instance) instance.difficulty = value; return; }
    }

    public static Material ColorScheme {
        get { if (instance) return instance.colorSchemes[instance.colorScheme]; return null; }
    }

    public int difficulty;
    public List<Material> colorSchemes;

    public List<int> unlockedColorSchemes { get; set; } // Indices into color scheme array
    public int colorScheme { get; set; } // Index into color scheme array

    void Awake() {
        DontDestroyOnLoad(this);

        if (!instance) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }

        unlockedColorSchemes = new List<int>();
        unlockedColorSchemes.Add(0);
    }

    public static bool UnlockColorScheme(int colorSchemeID) {
        if (instance && !instance.unlockedColorSchemes.Contains(colorSchemeID)) {
            instance.unlockedColorSchemes.Add(colorSchemeID);
            instance.colorScheme = colorSchemeID;

            if (colorSchemeID != 0) {
                Notification.NotifyColorSchemeUnlocked();
            }

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