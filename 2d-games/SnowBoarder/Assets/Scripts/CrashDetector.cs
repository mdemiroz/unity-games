using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour {

    [SerializeField] private float loadDelay = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;
    bool isCrushed = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !isCrushed) {
            isCrushed = true;
            Debug.Log("Ouch, I hit my head!");
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            GetComponent<PlayerController>().isKeysDisabled = true;
            crashEffect.Play();
            Invoke("ReloadScene", loadDelay);
       }
    }

    void ReloadScene() {
        // Loads the scene with index = 0 => Level1.
        SceneManager.LoadScene(0);
    }

}
