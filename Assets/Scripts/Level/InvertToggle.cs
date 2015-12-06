using UnityEngine;
using System.Collections;

public class InvertToggle : MonoBehaviour {

    void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            FullScreenInvert.Toggle();
        }
    }
}
