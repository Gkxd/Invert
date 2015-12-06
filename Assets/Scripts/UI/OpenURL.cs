using UnityEngine;
using System.Collections;

public class OpenURL : MonoBehaviour {

    public string url;

    void OnMouseDown() {
        Application.OpenURL(url);
    }
}
