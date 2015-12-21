using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public new Rigidbody rigidbody;
    public new Camera camera;
    public new PlayerBodyAnimation animation;
    public ScreenTransition screenTransition;
    public LayerMask groundLayer;
    public LayerMask invertLayer;

    [Header("Audio Setttings")]
    public AudioSource playerAudio;
    public AudioClip jumpSfx;

    [Header("Movement Settings")]
    public Vector3 gravity;
    public Vector3 jumpForce;

    public float moveSpeed;
    public float jumpSpeed;

    public bool inverted { get; private set; }
    public Vector3 checkpoint { get; set; }

    private bool jumpPending;

    void Start() {
        checkpoint = rigidbody.position;
    }

    void FixedUpdate() {
        if (ScreenTransition.isTransitioning) {
            rigidbody.Sleep();
            return;
        }

        float horizontalSpeed = ToggleGameUI.IsGamePaused ? 0 : moveSpeed * Input.GetAxisRaw("Horizontal");

        if (horizontalSpeed != 0) {
            animation.setDirection(horizontalSpeed);
            if (Physics.Raycast(transform.position, inverted ? Vector3.up : Vector3.down, 0.6f, groundLayer) && Time.time % 0.5f < 0.1f) {
                animation.addImpulse(0.5f);
            }
        }

        float verticalSpeed = rigidbody.velocity.y;

        if (jumpPending) {
            jumpPending = false;
            animation.stopSpring();
            verticalSpeed = jumpSpeed * (inverted ? -1 : 1);

            playerAudio.PlayOneShot(jumpSfx, AudioManager.sfxVolume);
        }

        rigidbody.velocity = new Vector3(horizontalSpeed, verticalSpeed);

        rigidbody.AddForce(gravity * (inverted ? -1 : 1));

        if (Input.GetKey(KeyCode.Space) && !ToggleGameUI.IsGamePaused) {
            rigidbody.AddForce(jumpForce * (inverted ? -1 : 1));
        }
    }

    void Update() {
        Vector3 screenPosition = camera.WorldToScreenPoint(transform.position);
        Ray r = camera.ScreenPointToRay(screenPosition);
        inverted = Physics.RaycastAll(r, 10, invertLayer).Length % 2 != 0;

        if (Input.GetKeyDown(KeyCode.Space) && !ToggleGameUI.IsGamePaused) {
            if (isTouchingGround()) {
                jumpPending = true;
            }
        }
    }

    private bool isTouchingGround() {
        int invertFactor = inverted ? 1 : -1;
        return Physics.Raycast(transform.position + 0.325f * Vector3.right, Vector3.up * invertFactor, 0.6f, groundLayer) ||
            Physics.Raycast(transform.position - 0.325f * Vector3.right, Vector3.up * invertFactor, 0.6f, groundLayer);
    }

    void OnCollisionEnter(Collision c) {
        if (c.gameObject.tag == "Ground") {
            animation.addImpulse(Mathf.Abs(c.impulse.y));
        }
    }

    public void respawnAtCheckpoint() {
        rigidbody.position = checkpoint;
        rigidbody.velocity = Vector3.zero;
    }
}
