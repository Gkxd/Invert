using UnityEngine;
using System.Collections;

public class AudioListenerOutput : MonoBehaviour {

    public static float[] audioData;

    void OnAudioFilterRead(float[] data, int channels) {
        audioData = data;
    }
}
