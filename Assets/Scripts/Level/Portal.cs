using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
    public AudioClip soundEffect;
    public Portal destination;

    private bool exiting = false;

    void OnTriggerEnter(Collider other) {
        if (!exiting) {
            destination.exiting = true;
            other.gameObject.transform.position = destination.transform.position;
            PlayerCamera.LerpMovement();
            AudioManager.SpawnSoundEffect(soundEffect, 1, transform);
        }
    }

    void OnTriggerExit(Collider other) {
        exiting = false;
    }
}
