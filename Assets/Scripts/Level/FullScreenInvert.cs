using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FullScreenInvert : MonoBehaviour {

    private static bool switchInvert, resetInvert;
    private static Vector3 spawnLocation;

    public GameObject invert;
    public Transform player;
    public AnimationCurve scale;

    private Queue<GameObject> spawnedInverts;

    void Start() {
        spawnedInverts = new Queue<GameObject>();
    }

    void Update() {
        if (switchInvert) {
            spawnInvert();

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

    private void spawnInvert() {
        GameObject spawnedInvert = (GameObject)Instantiate(invert, spawnLocation, Quaternion.identity);
        spawnedInvert.SetActive(true);
        spawnedInverts.Enqueue(spawnedInvert);
    }

    public static void Toggle(Vector3 location) {
        switchInvert = true;
        spawnLocation = location;
    }

    public static void Reset() {
        resetInvert = true;
    }
}
