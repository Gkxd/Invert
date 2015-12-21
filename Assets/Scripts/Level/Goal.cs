using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    public GameObject soundEffectPrefab;
    public string destinationName;

    private bool activated = false;

    void OnTriggerStay(Collider other) {
        if (!activated) {
            if (destinationName == "") {
                Debug.Log("Reached goal. (No scene assigned)");
            }
            else {
                //ScreenTransition screenTransition = other.transform.parent.Find("Camera/Foreground Camera/ScreenTransition").GetComponent<ScreenTransition>();

                //screenTransition.loadScene(destinationName);

                ScreenTransition.instance.loadScene(destinationName);

                Instantiate(soundEffectPrefab);
            }

            activated = true;
        }
    }
}
