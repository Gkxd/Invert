using UnityEngine;
using System.Collections;

public class StartBGM : MonoBehaviour {

    public AudioClip audioClip;
    [Range(0,1)]
    public float volume;

    public static GameObject audioSource;

    void Start() {
        if (audioSource == null) {
            audioSource = new GameObject("BGM");
            DontDestroyOnLoad(audioSource);

            AudioSource audio = audioSource.AddComponent<AudioSource>();
            audio.clip = audioClip;
            audio.volume = volume;
            audio.loop = true;
            audio.Play();
        }
    }
}
