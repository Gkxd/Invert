using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ScaleButtonWithMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {

    private float scale, targetScale, clickScale;

    void Start() {
        scale = targetScale = clickScale = 1;
    }

    void Update() {
        scale = Mathf.Lerp(scale, Mathf.Max(0.9f, targetScale * clickScale), Time.deltaTime * 10);
        transform.localScale = new Vector3(scale, scale, 1);
    }

    public void OnPointerEnter(PointerEventData p) {
        targetScale = 1.2f;
    }

    public void OnPointerExit(PointerEventData p) {
        targetScale = 1;
    }

    public void OnPointerDown(PointerEventData p) {
        clickScale = 0.7f;
    }
    public void OnPointerUp(PointerEventData p) {
        clickScale = 1;
    }
}
