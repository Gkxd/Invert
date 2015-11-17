using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip audioClip;

    public Renderer visualRenderer;

    public int difficulty = 4;

    private Material visualMaterial;
    private bool hasEntered;

    float alpha = 1;

    void Start() {
        visualMaterial = visualRenderer.material;

        if (difficulty < GameOptions.Difficulty) {
            gameObject.SetActive(false);
        }
    }

    void Update() {
        if (hasEntered) {
            visualMaterial.SetColor("_Color", Color.black * alpha);
            alpha = Mathf.Lerp(alpha, 0, Time.deltaTime * 10);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (!hasEntered) {
            hasEntered = true;
            other.gameObject.GetComponent<PlayerController>().checkpoint = transform.position;
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject, 2);
        }
    }
}
