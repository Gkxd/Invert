using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public new Rigidbody rigidbody;
    public new Camera camera;
    public new PlayerBodyAnimation animation;
    public ScreenTransition screenTransition;
    public LayerMask groundLayer;
    public LayerMask invertLayer;
    public ParticleSystem playerParticles;

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
    private bool gravityIncrease;

    void Start() {
        checkpoint = rigidbody.position;
    }

    void FixedUpdate() {
        float horizontalSpeed = moveSpeed * Input.GetAxisRaw("Horizontal");

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

            playerAudio.PlayOneShot(jumpSfx);
        }

        rigidbody.velocity = new Vector3(horizontalSpeed, verticalSpeed);
        rigidbody.AddForce(gravity * (inverted ? -1 : 1) * (gravityIncrease ? 2 : 1));
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

        gravityIncrease = Input.GetKey(KeyCode.LeftShift);

        /*
        if (Input.GetKeyDown(KeyCode.B)) {
            playerParticles.Emit(500);
        }
         */
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
