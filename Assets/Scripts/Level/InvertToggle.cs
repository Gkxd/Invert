using UnityEngine;
using System.Collections;

public class InvertToggle : MonoBehaviour {

    public AudioClip soundEffect;

    void OnTriggerEnter(Collider other) {
        FullScreenInvert.Toggle(transform.position);
        //AudioManager.SpawnSoundEffect(soundEffect, 1, transform);
    }
}