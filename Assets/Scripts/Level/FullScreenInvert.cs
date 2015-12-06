using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FullScreenInvert : MonoBehaviour {

    private static bool switchInvert, resetInvert;

    public GameObject invert;
    public Transform player;
    public AnimationCurve scale;

    private Queue<GameObject> spawnedInverts;

    void Start() {
        spawnedInverts = new Queue<GameObject>();
    }

    void Update() {
        if (switchInvert) {
            GameObject spawnedInvert = (GameObject)Instantiate(invert, transform.position, Quaternion.identity);
            spawnedInvert.SetActive(true);
            spawnedInverts.Enqueue(spawnedInvert);

            if (spawnedInverts.Count > 0 && spawnedInverts.Count % 2 == 0) {
                Destroy(spawnedInverts.Dequeue(), 2);
                Destroy(spawnedInverts.Dequeue(), 2);
            }

            switchInvert = false;
        }

        if (resetInvert) {
            while (spawnedInverts.Count > 0) {
                Destroy(spawnedInverts.Dequeue());
            }
            resetInvert = false;
        }

        transform.position = player.position;
    }

    public static void Toggle() {
        switchInvert = true;
    }

    public static void Reset() {
        resetInvert = true;
    }
}
