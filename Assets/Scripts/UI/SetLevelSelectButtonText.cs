using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class SetLevelSelectButtonText : MonoBehaviour {

    public int pageNumber;

    void Start() {
        int startNumber = pageNumber * 25 + 1;

        foreach (Transform t in transform) {
            t.Find("Text").GetComponent<Text>().text = "" + startNumber++;
        }
    }
}
