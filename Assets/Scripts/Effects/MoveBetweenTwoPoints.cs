using UnityEngine;
using System.Collections;

public class MoveBetweenTwoPoints : MonoBehaviour {

    public Transform A;
    public Transform B;

    public AnimationCurve movement;

    private Vector3 a;
    private Vector3 b;

    private float startTime;

    void Start() {
        a = A.position;
        b = B.position;

        startTime = Time.time;
    }

    void Update() {
        transform.position = Vector3.Lerp(a, b, movement.Evaluate(Time.time - startTime));
    }
}
