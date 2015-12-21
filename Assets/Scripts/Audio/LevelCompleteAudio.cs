using UnityEngine;
using System.Collections;

public class LevelCompleteAudio : MonoBehaviour {
    void Start() {
        GetComponent<AudioSource>().volume = AudioManager.sfxVolume;

        DontDestroyOnLoad(gameObject);
        Destroy(gameObject, 2);
    }
}
