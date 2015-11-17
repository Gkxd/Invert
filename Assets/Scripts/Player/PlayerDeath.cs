using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    public GameObject player { private get; set; }

    private float startTime;

    private bool respawned;

    void Start() {
        startTime = Time.time;
        GameScore.AddDeath();
    }

    void Update() {
        if (Time.time - startTime > 1 && !respawned) {
            ScreenTransition screenTransition = player.transform.parent.Find("Camera/Foreground Camera/ScreenTransition").GetComponent<ScreenTransition>();
            screenTransition.loadPlayerCheckpoint(player);
            Destroy(gameObject, 1);

            respawned = true;
        }
    }
}
