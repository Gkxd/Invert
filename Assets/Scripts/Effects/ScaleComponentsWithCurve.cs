using UnityEngine;
using System.Collections;

public class ScaleComponentsWithCurve : MonoBehaviour {

    public AnimationCurve scaleX;
    public AnimationCurve scaleY;
    public AnimationCurve scaleZ;
    private float startTime;

    void Start() {
        startTime = Time.time;
    }

    void Update() {
        float t = Time.time - startTime;
        transform.localScale = new Vector3(scaleX.Evaluate(t), scaleY.Evaluate(t), scaleZ.Evaluate(t));
    }
}
