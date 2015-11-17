using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LineRendererCircle : MonoBehaviour {

    public LineRenderer lineRenderer;

    void Update() {
        lineRenderer.SetVertexCount(101);

        for (int i = 0; i < 100; i++) {
            Quaternion q = Quaternion.Euler(new Vector3(0, 0, 360f * i / 100));
            Vector3 direction = q * transform.right;

            lineRenderer.SetPosition(i, direction);

            if (i == 0) {
                lineRenderer.SetPosition(100, direction);
            }
        }
    }
}
