using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class MultiplyLayer : MonoBehaviour {

    public Renderer renderer;
    public int unlockColorScheme = -1;

    void Start() {
        if (GameOptions.ColorScheme) {
            if (unlockColorScheme == -1) {
                renderer.material = GameOptions.ColorScheme;
            }
            else if (!GameOptions.UnlockColorScheme(unlockColorScheme)) {
                renderer.material = GameOptions.ColorScheme;
            }
        }

        if (renderer.material.mainTexture.wrapMode == TextureWrapMode.Repeat) {
            renderer.material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) / 16;
        }
        else {
            renderer.material.mainTextureScale = Vector2.one;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Material m = GameOptions.ToggleNextColorScheme();

            if (m) {
                if (m.mainTexture.wrapMode == TextureWrapMode.Repeat) {
                    m.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y) / 16;
                }
                else {
                    m.mainTextureScale = Vector2.one;
                }
                renderer.material = m;
            }
        }
    }
}
