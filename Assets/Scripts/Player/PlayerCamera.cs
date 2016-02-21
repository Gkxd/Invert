using UnityEngine;
using System.Collections;
using UsefulThings;

[ExecuteInEditMode]
public class PlayerCamera : MonoBehaviour {
    private static bool lerpMovement;
    private static float lerpTime;

    public Rect bounds;
    public Transform playerBody;

    private Vector3 offset = new Vector3(0, 0.1f, -3);

    void Update() {
        Vector3 targetPosition = playerBody.position + offset;

        targetPosition.x = Mathf.Clamp(targetPosition.x, bounds.xMin, bounds.xMax);
        targetPosition.y = Mathf.Clamp(targetPosition.y, bounds.yMin, bounds.yMax);

        if (!lerpMovement) {
            transform.position = targetPosition + CameraShake.CameraShakeOffset;
        }
        else {
#if UNITY_EDITOR
            if (Application.isPlaying) {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
                if ((transform.position - targetPosition).sqrMagnitude < 0.01 && Time.time - lerpTime > 0.1f) {
                    lerpMovement = false;
                }
            }
            else {
                transform.position = targetPosition;
            }
#else
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
            if ((transform.position - targetPosition).sqrMagnitude < 0.01 && Time.time - lerpTime > 0.1f) {
                lerpMovement = false;
            }
#endif
        }
    }

    public static void LerpMovement() {
        lerpMovement = true;
        lerpTime = Time.time;
    }
}
