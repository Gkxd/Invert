using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
[ExecuteInEditMode]
public class ScaleTexture : MonoBehaviour {

    public Renderer renderer;

    void Update() {
        renderer.material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }
}
