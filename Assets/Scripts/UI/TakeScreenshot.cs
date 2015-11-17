using UnityEngine;
using System.Collections;

public class TakeScreenshot : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            //Debug.Log(Application.dataPath + "/screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png");
            Application.CaptureScreenshot(Application.dataPath + "/../Screenshots/screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png");
        }
    }
}
