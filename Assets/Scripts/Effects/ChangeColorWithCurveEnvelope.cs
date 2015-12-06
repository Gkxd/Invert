using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class ChangeColorWithCurveEnvelope : MonoBehaviour {

    public Gradient color;
    public AnimationCurve curve;
    public AnimationCurve envelope;
    public float delay;

    private Material m;

    private float startTime;

    void Start() {
        startTime = Time.time;
        m = GetComponent<Renderer>().material;
    }


    void Update() {
        Color baseColor = color.Evaluate(curve.Evaluate(Time.time - startTime));
        m.SetColor("_Color", baseColor * new Color(1, 1, 1, envelope.Evaluate((Time.time - startTime) - delay)));
    }

    void OnEnable() {
        startTime = Time.time;
    }
}
