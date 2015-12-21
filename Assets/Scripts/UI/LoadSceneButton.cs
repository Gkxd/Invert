using UnityEngine;
using System.Collections;

public class LoadSceneButton : MonoBehaviour {

    public string destinationName;

    public void loadLevel() {
        ScreenTransition.instance.loadScene(destinationName);
    }
}
