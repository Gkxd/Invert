using UnityEngine;
using System.Collections;

public class Deathpoint : MonoBehaviour {
    public GameObject playerDeathPrefab;
    void OnTriggerEnter(Collider other) {
        other.gameObject.GetComponent<PlayerController>().respawnAtCheckpoint();
        PlayerCamera.LerpMovement();
        FullScreenInvert.Reset();

        GameObject playerDeath = (GameObject)Instantiate(playerDeathPrefab, other.transform.position, Quaternion.identity);
    }
}
