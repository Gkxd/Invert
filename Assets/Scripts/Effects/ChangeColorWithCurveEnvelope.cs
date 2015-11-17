using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class ChangeColorWithCurveEnvelope : MonoBehaviour {

    public Gradient color;
    public AnimationCurve curve;
    public AnimationCurve envelope;
    public float delay;

    private Material m;

    void Start() {
        m = GetComponent<Renderer>().material;
    }


    void Update() {
        Color baseColor = color.Evaluate(curve.Evaluate(Time.time));
        m.SetColor("_Color", baseColor * new Color(1, 1, 1, envelope.Evaluate(Time.timeSinceLevelLoad - delay)));
    }
}
