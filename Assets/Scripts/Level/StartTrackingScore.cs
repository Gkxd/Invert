using UnityEngine;
using System.Collections;

public class StartTrackingScore : MonoBehaviour {
	void Start () {
        GameScore.ScoreValid = true;
        GameScore.ResetScore();
	}
}
