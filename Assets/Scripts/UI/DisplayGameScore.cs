using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class DisplayGameScore : MonoBehaviour {

    public TextMesh textMesh;

    private int numberOfDeaths;
    private float timeTaken;

    private TimeSpan timeSpan;

    void Start() {
        timeTaken = GameScore.TimeTaken;
        numberOfDeaths = GameScore.NumberOfDeaths;

        timeSpan = TimeSpan.FromSeconds(timeTaken);

        string text = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        text += "\n" + numberOfDeaths;

        textMesh.text = text;
    }
}
