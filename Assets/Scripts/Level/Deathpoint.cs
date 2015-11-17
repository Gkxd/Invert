using UnityEngine;
using System.Collections;

public class Deathpoint : MonoBehaviour {
    public GameObject playerDeathPrefab;
    void OnTriggerEnter(Collider other) {
        other.gameObject.SetActive(false);
        GameObject playerDeath = (GameObject)Instantiate(playerDeathPrefab, other.transform.position, Quaternion.identity);

        playerDeath.GetComponent<PlayerDeath>().player = other.gameObject;
    }
}
