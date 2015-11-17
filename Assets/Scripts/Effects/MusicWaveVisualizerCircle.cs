using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicWaveVisualizerCircle : MonoBehaviour {

    public int samplesPerUnitRadius;
    public float sampleAmplitude;
    public int repetitionAmount;

    public LineRenderer lineRenderer;

    void Update() {
        float[] audioData = AudioListenerOutput.audioData;

        float radius = transform.localScale.x;
        transform.localScale = new Vector3(radius, radius, 1);

        int numSamples = (int)(samplesPerUnitRadius * radius);

        lineRenderer.SetVertexCount(numSamples * repetitionAmount + 1);

        float angle = 360f / (numSamples * repetitionAmount);
        float repetitionAngle = 360f / repetitionAmount;

        Vector3 initialPosition = Vector3.zero;
        for (int i = 0; i < numSamples; i++) {
            float r = 1 + sampleAmplitude * audioData[i % audioData.Length];

            for (int j = 0; j < repetitionAmount; j++) {
                float t = angle * i + j * repetitionAngle;

                Vector3 direction = Quaternion.Euler(new Vector3(0, 0, t)) * transform.right;

                lineRenderer.SetPosition(i + j * numSamples, direction * r);

                if (i == 0 && j == 0) {
                    lineRenderer.SetPosition(numSamples * repetitionAmount, direction * r);
                }
            }
        }
    }
}
