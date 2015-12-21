using UnityEngine;
using System.Collections;

public class InvertToggle : MonoBehaviour {

    public float delay = 1;

    private float lastTimeActivated;

    void OnTriggerStay(Collider other) {
        if (Time.time - lastTimeActivated > delay) {
            FullScreenInvert.Toggle(transform.position);
            lastTimeActivated = Time.time;
        }
    }
}
