using UnityEngine;
using System.Collections;

public class RotateAroundZWithCurve : MonoBehaviour {

    public AnimationCurve rotateSpeed;

    void Update() {
        float angle = transform.localEulerAngles.z;

        angle += rotateSpeed.Evaluate(Time.time) * Time.deltaTime;

        transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
