using UnityEngine;
using System.Collections;

public class MoveBetweenTwoPoints : MonoBehaviour {

    public Transform A;
    public Transform B;

    public AnimationCurve movement;

    private Vector3 a;
    private Vector3 b;

    void Start() {
        a = A.position;
        b = B.position;
    }

    void Update() {
        transform.position = Vector3.Lerp(a, b, movement.Evaluate(Time.time));
    }
}
