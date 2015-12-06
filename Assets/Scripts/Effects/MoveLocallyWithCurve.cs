using UnityEngine;
using System.Collections;

public class MoveLocallyWithCurve : MonoBehaviour {

    public AnimationCurve moveX;
    public AnimationCurve moveY;
    public AnimationCurve moveZ;

    private float startTime;

    void Start() {
        startTime = Time.time;
    }

    void Update() {
        transform.localPosition = new Vector3(moveX.Evaluate(Time.time - startTime), moveY.Evaluate(Time.time - startTime), moveZ.Evaluate(Time.time - startTime));
    }
}
