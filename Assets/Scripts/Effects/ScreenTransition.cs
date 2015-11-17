using UnityEngine;
using System.Collections;

public class ScreenTransition : MonoBehaviour {

    public Camera camera;
    public GameObject screenTransitionQuad;

    public int quadPixelSize;

    public AnimationCurve rotationCurve;
    public AnimationCurve scaleCurve;
    public float rotateAmount;
    public float overlap;

    public float delayX;
    public float delayY;
    public float domainMin;
    public float domainMax;

    private GameObject[,] quads;
    private Vector3 baseScale;

    private float time;
    private float targetTime;

    private bool loadCheckpointTransitionA;
    private bool loadCheckpointTransitionB;
    private string nextSceneName;

    private GameObject spawnPlayer;

    void Start() {
        int numQuadX = Screen.width / quadPixelSize;
        int numQuadY = Screen.height / quadPixelSize;

        quads = new GameObject[numQuadX + 1, numQuadY + 1];

        Vector3 worldStartPosition = camera.ScreenToWorldPoint(Vector3.zero);
        Vector3 worldOffset = camera.ScreenToWorldPoint(new Vector3(quadPixelSize, quadPixelSize, 2)) - worldStartPosition;

        baseScale = new Vector3(worldOffset.x + overlap, worldOffset.y + overlap, 1);

        for (int xi = 0; xi <= numQuadX; xi++) {
            for (int yi = 0; yi <= numQuadY; yi++) {
                Vector3 position = worldStartPosition + worldOffset / 2 + Vector3.Scale(worldOffset, new Vector3(xi, yi, 1));

                quads[xi, yi] = (GameObject)Instantiate(screenTransitionQuad, position, Quaternion.identity);
                quads[xi, yi].name = "Screen Transition Quad (" + xi + ", " + yi + ")";
                quads[xi, yi].transform.parent = transform;

                quads[xi, yi].transform.localScale = baseScale;
            }
        }

        time = domainMin;
        targetTime = domainMax;

        nextSceneName = "";
    }

    void Update() {
        if (Mathf.Abs(time - targetTime) > 0.05) {
            for (int xi = 0; xi < quads.GetLength(0); xi++) {
                for (int yi = 0; yi < quads.GetLength(1); yi++) {

                    float t = time - xi * delayX / quads.GetLength(0) - yi * delayY / quads.GetLength(1);

                    quads[xi, yi].transform.localScale = Vector3.Scale(baseScale, new Vector3(scaleCurve.Evaluate(t), scaleCurve.Evaluate(t), 1));
                    quads[xi, yi].transform.localEulerAngles = new Vector3(1, 1, rotationCurve.Evaluate(t) * rotateAmount);
                }
            }

            time = Mathf.Lerp(time, targetTime, Time.deltaTime);
        }
        else {
            if (loadCheckpointTransitionB) {
                loadCheckpointTransitionB = false;
            }
            else {
                time = targetTime;
            }
        }

        if (time < 0) {
            if (nextSceneName != "") {
                Application.LoadLevel(nextSceneName);
            }
            else if (loadCheckpointTransitionA) {
                flipDelays();
                targetTime = domainMax;
                time = domainMin;
                loadCheckpointTransitionA = false;
                loadCheckpointTransitionB = true;

                spawnPlayer.SetActive(true);
                spawnPlayer.GetComponent<PlayerController>().respawnAtCheckpoint();
            }
        }
    }

    private void flipDelays() {
        delayX *= -1;
        delayY *= -1;
    }

    public void loadScene(string sceneName) {
        flipDelays();
        targetTime = domainMin;
        nextSceneName = sceneName;
    }

    public void loadPlayerCheckpoint(GameObject player) {
        flipDelays();
        loadCheckpointTransitionA = true;
        loadCheckpointTransitionB = false;
        targetTime = domainMin;
        spawnPlayer = player;
    }
}
