using UnityEngine;
using System.Collections;

public class PlayerBodyScale : MonoBehaviour {

    public Transform topAnchor;
    public Transform bottomAnchor;
    public Transform playerEyes;

    public AnimationCurve topScale;
    public AnimationCurve bottomScale;
    public AnimationCurve eyeScale;
    public AnimationCurve width;

    public void setScale(float scale) {
        float topScaleY = topScale.Evaluate(scale);
        float bottomScaleY = bottomScale.Evaluate(scale);
        float eyeScaleY = eyeScale.Evaluate(scale);

        float topOffset = -0.234375f + 0.265625f * (bottomScaleY - 1);

        topAnchor.localScale = new Vector3(1, topScaleY, 1);
        bottomAnchor.localScale = new Vector3(1, bottomScaleY, 1);
        playerEyes.localScale = new Vector3(1, eyeScaleY, 1);

        topAnchor.localPosition = new Vector3(0, topOffset, 0);

        transform.localScale = new Vector3(width.Evaluate(scale), 1, 1);
    }
}
