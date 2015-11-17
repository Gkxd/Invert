using UnityEngine;
using System.Collections;

public class ScaleWithCurve : MonoBehaviour {

    public AnimationCurve scale;

    void Update() {
        transform.localScale = Vector3.one * scale.Evaluate(Time.time);
    }
}
