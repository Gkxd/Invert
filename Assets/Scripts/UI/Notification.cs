using UnityEngine;
using System.Collections;

public class Notification : MonoBehaviour {
    private static bool notifyColorScheme;
    private static bool notifySecret;

    public GameObject colorSchemeUnlocked;
    public GameObject secretFound;

    void Update() {
        if (notifyColorScheme) {
            GameObject message = (GameObject)Instantiate(colorSchemeUnlocked);
            message.transform.parent = transform;
            message.transform.localPosition = Vector3.forward;
            notifyColorScheme = false;
        }

        if (notifySecret) {
            GameObject message = (GameObject)Instantiate(secretFound);
            message.transform.parent = transform;
            message.transform.localPosition = Vector3.forward;
            notifySecret = false;
        }
    }

    public static void NotifyColorSchemeUnlocked() {
        notifyColorScheme = true;
    }

    public static void NotifySecretFound() {
        notifySecret = true;
    }
}
