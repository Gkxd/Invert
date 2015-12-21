using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UnlockLevel : MonoBehaviour {
    void Start() {
        GameScore.UnlockLevel(SceneManager.GetActiveScene().name);
    }
}
