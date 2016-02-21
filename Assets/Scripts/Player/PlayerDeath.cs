using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    private bool respawned;

    void Start() {
        GameScore.AddDeath();
        GetComponent<AudioSource>().volume = AudioManager.sfxVolume;
        Destroy(gameObject, 2);
    }
}
