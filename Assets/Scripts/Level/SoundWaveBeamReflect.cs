using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SoundWaveBeamReflect : MonoBehaviour {

    public Transform soundWaveTransform;
    public Transform reflectedBeamStart;

    public LayerMask walls;
    public float maxDistance;

    void Start() {

    }

    void Update() {
        RaycastHit raycastInfo;
        if (Physics.Raycast(transform.position, transform.right, out raycastInfo, maxDistance, walls)) {
            soundWaveTransform.localScale = new Vector3(raycastInfo.distance, 1, 1);
            if (reflectedBeamStart != null) {
                reflectedBeamStart.position = raycastInfo.point;
                reflectedBeamStart.GetComponent<SoundWaveBeamReflect>().maxDistance = Mathf.Max(0, maxDistance - raycastInfo.distance);

                Vector3 reflectedDirection = Vector3.Reflect(transform.right, raycastInfo.normal);
                reflectedBeamStart.right = reflectedDirection;
            }
        }
        else {
            soundWaveTransform.localScale = new Vector3(maxDistance, 1, 1);
            if (reflectedBeamStart != null) {
                reflectedBeamStart.position = transform.position + transform.right * maxDistance;
                reflectedBeamStart.GetComponent<SoundWaveBeamReflect>().maxDistance = 0;
            }
        }
    }
}
