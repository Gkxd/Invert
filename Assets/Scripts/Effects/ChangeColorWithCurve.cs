using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class ChangeColorWithCurve : MonoBehaviour {

    public Gradient color;
    public AnimationCurve curve;

    private Material m;

    void Start() {
        m = GetComponent<Renderer>().material;
    }


    void Update() {
        m.SetColor("_Color", color.Evaluate(curve.Evaluate(Time.time)));
    }
}
