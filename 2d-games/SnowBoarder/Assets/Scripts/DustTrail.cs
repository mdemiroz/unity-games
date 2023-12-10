using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour {

    bool isTouchingGround;
    [SerializeField] private ParticleSystem dustTrail;
    void Start()  {
        isTouchingGround = false;
    }

    // Update is called once per frame
    void Update() {
        if(isTouchingGround)
            dustTrail.Play();
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Ground") {
            Debug.Log("OnTriggerEnter2D");
            isTouchingGround = true;
       }
    }
    private void OnTriggerExit2D(Collider2D other) {
       if(other.tag == "Ground") {
            Debug.Log("OnTriggerExit2D");
            isTouchingGround = false;
       }
    }

    private void OnCollusionEnter2D(Collision2D other) {
        Debug.Log("OnCollusionEnter2D");
        isTouchingGround = true;
    }

    private void OnCollusionExit2D(Collision2D other) {
        Debug.Log("OnCollusionExit2D");
        isTouchingGround = false;
    }
}
