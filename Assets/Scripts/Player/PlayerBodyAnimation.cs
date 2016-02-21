using UnityEngine;
using System.Collections;
using UsefulThings;

public class PlayerBodyAnimation : MonoBehaviour {

    public PlayerBodyScale playerScale;
    public Rigidbody playerRigidbody;
    public Transform playerEyesDirection;

    public AnimationCurve velocityStretch;
    public float springConstant, springDamping;

    private float springHeight;
    private float springVelocity;
    private float springForce;

    private float stretch;
    private float targetStretch;

    private float eyeAngle;
    private float targetEyeAngle;

    void Start() {
        eyeAngle = targetEyeAngle = -40;
    }

    void Update() {
        springHeight += springVelocity * Time.deltaTime;
        springVelocity += springForce * Time.deltaTime;
        springForce = -springConstant * springHeight - springDamping * springVelocity;

        targetStretch = springHeight + velocityStretch.Evaluate(Mathf.Abs(playerRigidbody.velocity.y));

        stretch = Mathf.Lerp(stretch, targetStretch, 10 * Time.deltaTime);

        float scale = 0.5f + stretch;

        playerScale.setScale(scale);

        eyeAngle = Mathf.Lerp(eyeAngle, targetEyeAngle, 5 * Time.deltaTime);
        playerEyesDirection.localEulerAngles = new Vector3(0, eyeAngle, 0);
    }

    public void addImpulse(float amount) {
        if (amount > 20) {
            CameraShake.ShakeCamera((amount - 19)/5, 0.3f);
        }
        springVelocity -= Mathf.Clamp(amount, 0, 10);
    }

    public void stopSpring() {
        springHeight = 0;
        springVelocity = 0;
        springForce = 0;
    }

    public void setDirection(float horizontalMovement) {
        targetEyeAngle = -40 * Mathf.Sign(horizontalMovement);
    }
}
