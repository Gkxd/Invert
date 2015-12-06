using UnityEngine;
using System.Collections;

public class ToggleDifficulty : MonoBehaviour {

    public GameObject normal;
    public GameObject hard;
    public GameObject currentDisplay;

    private float scale;
    private float targetScale;

    private float clickTime;

    void Start() {
        scale = targetScale = 1;
    }

    void Update() {
        scale = Mathf.Lerp(scale, targetScale, Time.deltaTime * 10);
        transform.localScale = new Vector3(scale, scale, 1);
    }

    void OnMouseEnter() {
        targetScale = 1.1f;
    }

    void OnMouseExit() {
        targetScale = 1;
    }

    void OnMouseDown() {
        if (Time.time - clickTime > 1) {
            clickTime = Time.time;
            if (GameOptions.Difficulty == 1) {
                GameOptions.Difficulty = 0;

                Destroy(currentDisplay);
                currentDisplay = (GameObject)Instantiate(normal);
                currentDisplay.transform.parent = transform;
                currentDisplay.SetActive(true);
            }
            else if (GameOptions.Difficulty == 0) {
                GameOptions.Difficulty = 1;

                Destroy(currentDisplay);
                currentDisplay = (GameObject)Instantiate(hard);
                currentDisplay.transform.parent = transform;
                currentDisplay.SetActive(true);
            }
        }
    }
}
