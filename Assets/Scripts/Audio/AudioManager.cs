using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public AudioClip audioClip;
    [Range(0,1)]
    public float initialVolume;

    public static AudioSource audioSource;

    public static float sfxVolume = 0.5f;

    void Start() {
        if (instance) return;

        instance = this;
        if (audioSource == null) {
            GameObject audio = new GameObject("BGM");
            DontDestroyOnLoad(audio);

            audioSource = audio.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = initialVolume;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void setBgmVolume(float v) {
        if (audioSource) {
            audioSource.volume = v;
        }
    }

    public void setSfxVolume(float v) {
        sfxVolume = v;
    }

    public static void SpawnSoundEffect(AudioClip sfx, float length, Transform t) {
        GameObject soundEffectObject = new GameObject("Spawned Sound Effect");
        soundEffectObject.transform.position = t.position;

        AudioSource soundEffectSource = soundEffectObject.AddComponent<AudioSource>();
        soundEffectSource.clip = sfx;
        soundEffectSource.volume = sfxVolume;
        soundEffectSource.Play();

        DontDestroyOnLoad(soundEffectObject);
        Destroy(soundEffectObject, length);
    }
}
