using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class EnforceAspect : MonoBehaviour {

    public float targetAspectRatio = 16f/9;

    // Adapted from http://wiki.unity3d.com/index.php?title=AspectRatioEnforcer
    void Start() {
        float currentAspectRatio = (float)Screen.width / Screen.height;

        Camera camera = GetComponent<Camera>();

        if ((int)(currentAspectRatio * 100) / 100.0f == (int)(targetAspectRatio * 100) / 100.0f) {
            camera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
            return;
        }

        if (currentAspectRatio > targetAspectRatio) {
            float inset = 1.0f - targetAspectRatio / currentAspectRatio;
            camera.rect = new Rect(inset / 2, 0.0f, 1.0f - inset, 1.0f);
        }
        else {
            float inset = 1.0f - currentAspectRatio / targetAspectRatio;
            camera.rect = new Rect(0.0f, inset / 2, 1.0f, 1.0f - inset);
        }
    }
}
