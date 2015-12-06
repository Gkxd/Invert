using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

    public float seconds;

    void Start() {
        Destroy(gameObject, seconds);
    }
}
