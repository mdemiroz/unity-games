using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour {


    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float disappearDelay;
    bool isPackageAcquired; // default value is False.

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch");
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Package" && !isPackageAcquired) {
            Debug.Log("Package is acquired.");
            isPackageAcquired = true;
            Destroy(other.gameObject, disappearDelay);
            spriteRenderer.color = hasPackageColor;
       } else if(other.tag == "Customer" && isPackageAcquired) {
            Debug.Log("Package is delivered.");
            isPackageAcquired = false;
            spriteRenderer.color = noPackageColor;
       }
    }

}
