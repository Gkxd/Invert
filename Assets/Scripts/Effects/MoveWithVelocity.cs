using UnityEngine;
using System.Collections;

public class MoveWithVelocity : MonoBehaviour {

    public Vector3 velocity;
	
	void Update () {
        transform.position = transform.position + velocity * Time.deltaTime;
	}
}
