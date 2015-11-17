using UnityEngine;
using System.Collections;

public class LevelCompleteAudio : MonoBehaviour {
    void Start() {
        DontDestroyOnLoad(gameObject);
        Destroy(gameObject, 5);
    }
}
