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
        timeSpan = TimeSpan.FromSeconds(GameScore.TimeTaken);

        string text = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        text += "\n" + GameScore.NumberOfDeaths;
        text += "\n" + GameScore.SecretsFound + "/2";

        textMesh.text = text;
    }
}
