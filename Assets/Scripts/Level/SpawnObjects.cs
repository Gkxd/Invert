using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

    public float timeBetweenSpawn;
    public GameObject objectToSpawn;
    public float objectLifetime;

    private float startTime;

    void Start() {
        startTime = Time.time;
        spawn();
    }

    void Update() {
        if (Time.time - startTime > timeBetweenSpawn) {
            startTime = Time.time;
            spawn();
        }
    }

    private void spawn() {
        GameObject spawnedObject = (GameObject)Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        spawnedObject.SetActive(true);
        spawnedObject.transform.parent = transform;
        Destroy(spawnedObject, objectLifetime);
    }
}
