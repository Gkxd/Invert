using UnityEngine;
using System.Collections;

public class RotateAroundZ : MonoBehaviour {

    public float speed, offset;

    private float angle;

    void Start() {
        angle = offset;
    }

    void Update() {
        transform.localEulerAngles = Vector3.forward * (angle += Time.deltaTime * speed);
        angle %= 360;
    }
}