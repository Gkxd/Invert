using UnityEngine;
using System.Collections;

public class SlideTitleUI : MonoBehaviour {

    public RectTransform transform;

    Vector3 targetPosition;

    void Start() {
        targetPosition = transform.localPosition;
    }

    void Update() {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * 5);
    }

    public void slideOffscreen() {
        targetPosition = new Vector3(-323.5f, 0, 0);
    }

    public void slideOnscreen() {
        targetPosition = new Vector3(323.5f, 0, 0);
    }
}
