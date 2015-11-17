using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SoundWaveBeam : MonoBehaviour {

    public Transform soundWaveTransform;
    public Transform endpointTransform;

    public LayerMask walls;
    public float maxDistance;

    void Update() {
        RaycastHit raycastInfo;
        if (Physics.Raycast(transform.position, transform.right, out raycastInfo, maxDistance, walls)) {
            soundWaveTransform.localScale = new Vector3(raycastInfo.distance, 1, 1);
            endpointTransform.localPosition = Vector3.right * raycastInfo.distance;
        }
        else {
            soundWaveTransform.localScale = new Vector3(maxDistance, 1, 1);
            endpointTransform.localPosition = Vector3.right * maxDistance;
        }
    }
}
