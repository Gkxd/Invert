using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Renderer))]
public class SetRenderQueue : MonoBehaviour {
    public new Renderer renderer;
    public int renderQueue;
    void Start() {
        renderer.sharedMaterial.renderQueue = renderQueue;
    }
}
