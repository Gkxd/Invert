using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PlayerCamera : MonoBehaviour {

    public Rect bounds;
    public Transform playerBody;

    private Vector3 offset = new Vector3(0, 0.1f, -3);

    void Update() {
        Vector3 unclampedPosition = playerBody.position + offset;

        float x = Mathf.Clamp(unclampedPosition.x, bounds.xMin, bounds.xMax);
        float y = Mathf.Clamp(unclampedPosition.y, bounds.yMin, bounds.yMax);

        transform.position = new Vector3(x, y, unclampedPosition.z);
    }
}
