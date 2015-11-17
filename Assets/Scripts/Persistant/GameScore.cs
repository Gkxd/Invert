using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

    public static GameScore instance;

    public static int NumberOfDeaths { get { if (instance) return instance.numberOfDeaths; return 0; } }
    public static float TimeTaken { get { if (instance) return Time.time - instance.startTime; return 0; } }

    private float startTime;
    private int numberOfDeaths;

    void Awake() {
        DontDestroyOnLoad(this);

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
}
