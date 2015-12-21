using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIBackground : MonoBehaviour {

    public Image image;
    public Color targetColor;

	void Update () {
        image.color = Color.Lerp(image.color, targetColor, Time.deltaTime * 5);
	}
}
