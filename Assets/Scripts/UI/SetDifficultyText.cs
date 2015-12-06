using UnityEngine;
using System.Collections;

public class SetDifficultyText : MonoBehaviour {

    public TextMesh text;

	void Start () {
        if (GameOptions.Difficulty == 0) {
            text.text = "Normal";
        }
        else if (GameOptions.Difficulty == 1) {
            text.text = "Hard";
        }
	}
}
