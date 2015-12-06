using UnityEngine;
using System.Collections;

public class UnlockSecret : MonoBehaviour {
    public int secretID;

    void OnTriggerEnter(Collider other) {
        GameScore.AddSecret(secretID);
        Notification.NotifySecretFound();
        Destroy(gameObject);
    }
}
