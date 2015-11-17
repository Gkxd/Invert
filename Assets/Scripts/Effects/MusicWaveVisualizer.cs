using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicWaveVisualizer : MonoBehaviour {

    public int samplesPerUnit;
    public float sampleAmplitude;

    public LineRenderer lineRenderer;

    void Update() {
        float[] audioData = AudioListenerOutput.audioData;

        float length = transform.localScale.x;
        int numSamples = (int)(samplesPerUnit * length);

        lineRenderer.SetVertexCount(numSamples);
        for (int i = 0; i < numSamples; i++) {
            float x = i * (1f/numSamples);
            float y = sampleAmplitude * audioData[i % audioData.Length];

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
