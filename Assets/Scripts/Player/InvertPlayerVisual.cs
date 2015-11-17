using UnityEngine;
using System.Collections;

public class InvertPlayerVisual : MonoBehaviour {
    public PlayerController controller;

    private float scale;
    private float targetScale;

    void Update() {
        targetScale = controller.inverted ? -1 : 1;
        scale = Mathf.Lerp(scale, targetScale, 10 * Time.deltaTime);

        transform.localScale = new Vector3(1, scale, 1);
    }
}
