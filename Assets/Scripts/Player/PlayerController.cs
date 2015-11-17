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

    public float moveSpeed;
    public float jumpSpeed;

    public bool inverted { get; private set; }
    public Vector3 checkpoint { get; set; }

    private bool jumpPending;

    void Start() {
        checkpoint = rigidbody.position;
    }

    void FixedUpdate() {
        float horizontalSpeed = moveSpeed * Input.GetAxisRaw("Horizontal");

        if (horizontalSpeed != 0) {
            animation.setDirection(horizontalSpeed);
        }

        float verticalSpeed = rigidbody.velocity.y;

        if (jumpPending) {
            jumpPending = false;
            animation.stopSpring();
            verticalSpeed = jumpSpeed * (inverted ? -1 : 1);

            playerAudio.PlayOneShot(jumpSfx);
        }

        rigidbody.velocity = new Vector3(horizontalSpeed, verticalSpeed);
        rigidbody.AddForce(gravity * (inverted ? -1 : 1));
    }

    void Update() {
        Vector3 screenPosition = camera.WorldToScreenPoint(transform.position);
        Ray r = camera.ScreenPointToRay(screenPosition);
        inverted = Physics.RaycastAll(r, 10, invertLayer).Length % 2 != 0;

        if (inverted) {
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                if (Physics.Raycast(transform.position + 0.325f * Vector3.right, Vector3.up, 0.6f, groundLayer) ||
                    Physics.Raycast(transform.position - 0.325f * Vector3.right, Vector3.up, 0.6f, groundLayer)) {
                    jumpPending = true;
                }
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                if (Physics.Raycast(transform.position + 0.325f * Vector3.right, Vector3.down, 0.6f, groundLayer) ||
                    Physics.Raycast(transform.position - 0.325f * Vector3.right, Vector3.down, 0.6f, groundLayer)) {
                    jumpPending = true;
                }
            }
        }
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
