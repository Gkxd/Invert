using UnityEngine;
using System.Collections;

public class ScaleWithCurve : MonoBehaviour {

    public AnimationCurve scale;
    private float startTime;

    void Start() {
        startTime = Time.time;
    }

    void Update() {
        transform.localScale = Vector3.one * scale.Evaluate(Time.time - startTime);
    }
}
