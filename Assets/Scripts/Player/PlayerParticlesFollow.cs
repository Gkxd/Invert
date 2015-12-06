using UnityEngine;
using System.Collections;

public class PlayerParticlesFollow : MonoBehaviour {

    public Transform player;
	
	void Update () {
        transform.position = player.position;
	}
}
