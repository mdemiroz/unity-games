using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {

    [SerializeField] private float loadDelay = 1f;
    [SerializeField] private ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Player") {
            Debug.Log("Finish line has reached.");
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", loadDelay);
       }
    }

    void ReloadScene() {
        // Loads the scene with index = 0 => Level1.
        SceneManager.LoadScene(0);
    }

}
